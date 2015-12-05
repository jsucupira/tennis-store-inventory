using System;
using Core.Common.Model;
using Domain.MasterData.Validations;
using FluentValidation;

namespace Domain.MasterData.ProductAggregate
{
    public sealed class Photo : Entity<Guid>
    {
        private Photo()
        {
            Id = Guid.NewGuid();
            IsActive = true;
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
        }

        public Photo(string productId, string largePhotoUrl, string largePhotoFileName) : this()
        {
            LargePhotoUrl = largePhotoUrl;
            LargePhotoFileName = largePhotoFileName;
            ProductId = productId;
        }

        public DateTime CreatedDate { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsLocked { get; private set; }
        public string LargePhotoUrl { get; set; }
        public string LargePhotoFileName { get; set; }
        public string LastModifiedBy { get; private set; }
        public DateTime LastModifiedDate { get; private set; }
        public string LockedBy { get; private set; }
        public string ProductId { get; private set; }
        public string ThumbNailPhotoUrl { get; set; }

        public void Activate()
        {
            IsActive = true;
        }

        public void DeActivate()
        {
            IsActive = false;
        }

        protected override IValidator GetValidator()
        {
            return new PhotoValidator();
        }

        public void LockEntity(string lockedBy)
        {
            IsLocked = true;
            LockedBy = lockedBy;
        }

        public void ModifiedBy(string userName)
        {
            LastModifiedBy = userName;
        }

        public void SetThumbnail(string thumbnailUrl)
        {
            ThumbNailPhotoUrl = thumbnailUrl;
        }

        public void UnlockEntity()
        {
            IsLocked = false;
        }
    }
}