using Bazzar.Core.Domain.Advertisements.Events;
using Bazzar.Core.Domain.Advertisements.ValueObjects;
using Framework.Tools.Enums;
using Framework.Domain.Entieis;
using Framework.Domain.Events;
using Framework.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Core.Domain.Advertisements.Entities
{

    public class Advertisment : BaseAggregateRoot<Guid>
    {
        public UserId OwnerId { get; protected set; }
        public UserId ApprovedBy { get; protected set; } = new UserId(Guid.NewGuid());
        public AdvertismentTitle Title { get; protected set; }
        public AdvertismentText Text { get; protected set; }
        public Price Price { get; protected set; }
        public AdvertismentState State { get; protected set; }
        public List<Picture> Pictures { get; private set; }

        public Advertisment(Guid id, UserId ownerId)
        {
            Pictures = new List<Picture>();

            HandleEvent(new AdvertismentCreated()
            {
                OwnerId = ownerId.Value,
                Id = id,
            });
        }

        public void SetTitle(AdvertismentTitle title)
        {
            HandleEvent(new AdvertismentTitleChanged()
            {
                Title = title.Value,
                Id = Id,
            });
        }
        public void UpdateText(AdvertismentText text)
        {

            HandleEvent(new AdvertismentTextUpdated()
            {
                AdvertismentText = text.Value,
                Id = Id,
            });
        }
        public void UpdatePrice(Price price)
        {

            HandleEvent(new AdvertismentPriceUpdated()
            {
                Price = price.Value,
                Id = Id,
            });
        }

        public void RequestToPublish()
        {
            HandleEvent(new AdvertismentSentForReview()
            {
                Id = Id,
            });
        }


        protected override void ValidateInvariants()
        {
            var isValid =
                Id != null &&
                OwnerId != null &&
                (State switch
                {
                    AdvertismentState.ReviewPending =>
                        Title != null
                        && Text != null
                        && Price != null,
                    //&& !Pictures.Any(),
                    AdvertismentState.Active =>
                        Title != null
                        && Text != null
                        && Price != null
                        && ApprovedBy != null,
                    //&& !Pictures.Any(),
                    _ => true
                });
            if (!isValid)
            {
                                           // این کد باید گذاشته شود
                ////////////////////////{State.GetDescription()} //////////////////////
                throw new InvalidEntityStateException(this, $"مقدار تنظیم شده برای آگهی در وضیعت {State.GetDescription()}  غیر قابل قبول است");
            }
        }

        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case AdvertismentCreated e:
                    Id = e.Id;
                    OwnerId = new UserId(e.OwnerId);
                    State = AdvertismentState.Inactive;
                    break;
                case AdvertismentPriceUpdated e:
                    Price = new Price(Rial.FromLong(e.Price));
                    break;
                case AdvertismentSentForReview e:
                    State = AdvertismentState.ReviewPending;
                    break;
                case AdvertismentTextUpdated e:
                    Text = new AdvertismentText(e.AdvertismentText);
                    break;
                case AdvertismentTitleChanged e:
                    Title = new AdvertismentTitle(e.Title);
                    break;

                default:
                    throw new InvalidOperationException("امکان اجرای عملیات درخواستی وجود ندارد");
            }
        }

        public void AddPicture(Uri pictureUri, PictureSize size)
        {
            var newPic = new Picture(HandleEvent);
            newPic.HandleEvent(new PictureAddedToAdvertisment
            {
                PictureId = new Guid(),
                ClassifiedAdId = Id,
                Url = pictureUri.ToString(),
                Height = size.Height,
                Width = size.Width
            });
            Pictures.Add(newPic);
        }
        public void ResizePicture(Guid pictureId, PictureSize newSize)
        {
            var picture = FindPicture(pictureId);
            if (picture == null)
                throw new InvalidOperationException(
                "تصویری با شناسه وارد شده وجود برای تغییر سایز وجود ندارد");
            picture.Resize(newSize);
        }
        private Picture FindPicture(Guid id) => Pictures.FirstOrDefault(x => x.Id == id);


    }
}
