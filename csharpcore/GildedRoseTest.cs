using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void SellInIsReducedByOneEachDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].SellIn.Should().Be(0);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 3, 1)]
        public void NormalItemQualityReducesCorrectly(int sellIn, int quality, int expectedQuality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(expectedQuality);
        }
        
        [Fact]
        public void MaxQualityShouldNotExceedFifty()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(50);
        }

        [Fact]
        public void AgedBrieIncreasesInQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(2);
        }

        [Fact]
        public void Sulfuras()
        {
            true.Should().BeFalse();
        }
        
        [Theory]
        [InlineData(11, 1, 2)]
        [InlineData(10, 1, 3)]
        [InlineData(5, 1, 4)]
        [InlineData(0, 10, 0)]
        public void BackstagePassesQualityUpdatesCorrectly(int sellIn, int quality, int expectedQuality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(expectedQuality);
        }
    }
}