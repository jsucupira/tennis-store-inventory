using System;
using System.Diagnostics.CodeAnalysis;
using Core.Common.Model;
using Domain.MasterData.Validations;
using FluentValidation;

namespace Domain.MasterData.ProductAggregate
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public sealed class Photo : Entity<Guid>
    {
        private Photo()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }

        public Photo(string productId, string largePhotoUrl, string largePhotoFileName) : this()
        {
            LargePhotoUrl = largePhotoUrl;
            LargePhotoFileName = largePhotoFileName;
            ProductId = productId;
        }

        public string LargePhotoUrl { get; set; }
        public string LargePhotoFileName { get; set; }
        public string ProductId { get; private set; }
        public string ThumbNailPhotoUrl { get; set; }

        protected override IValidator GetValidator()
        {
            return new PhotoValidator();
        }

        public void SetThumbnail(string thumbnailUrl)
        {
            ThumbNailPhotoUrl = thumbnailUrl;
        }
    }
}