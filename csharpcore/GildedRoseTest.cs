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

        [Fact]
        public void QualityIsReducedByOneEachDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(0);
        }
        
        [Fact]
        public void QualityNeverDropsBelowZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(0);
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
        
        [Theory]
        [InlineData(10, 1, 3)]
        public void BackstagePassesIncreaseInQualityByTwoWhenTenDaysOrLess(int sellIn, int quality, int expectedQuality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(expectedQuality);
        }
    }
}