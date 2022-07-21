﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DofitAPI.Models
{
    public class Sell
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? Item_id { get; set; }

        [BsonElement("PurchasePrice")]
        public int PurchasePrice { get; set; }

        [BsonElement("SellingPrice")]
        public int SellingPrice { get; set; }

        [BsonElement("Profit")]
        public int Profit { get; set; }

        [BsonElement("Sold")]
        public bool Sold { get; set; }

        [BsonElement("Margin")]
        public double Margin { get; set; }

        [BsonElement("Comments")]
        public string? Comments { get; set; }

        [BsonElement("ListingDate")]
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime ListingDate { get; set; }

        [BsonElement("SellingDate")]
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime SellingDate { get; set; }
    }
}
