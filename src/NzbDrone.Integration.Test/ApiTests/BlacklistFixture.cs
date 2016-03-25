﻿using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using NzbDrone.Api.Series;
using System.Linq;
using NzbDrone.Test.Common;

namespace NzbDrone.Integration.Test.ApiTests
{
    [TestFixture]
    public class BlacklistFixture : IntegrationTest
    {
        private SeriesResource _series;

        [Test]
        [Ignore]
        public void should_be_able_to_add_to_blacklist()
        {
            _series = this.EnsureSeries("The Blacklist");

            Blacklist.Post(new Api.Blacklist.BlacklistResource
            {
                SeriesId = _series.Id,
                SourceTitle = "Blacklist.S01E01.Brought.To.You.By-BoomBoxHD"
            });
        }

        [Test]
        [Ignore]
        public void should_be_able_to_get_all_blacklisted()
        {
            var result = Blacklist.GetPaged(0, 1000, "date", "desc");

            result.Should().NotBeNull();
            result.TotalRecords.Should().Be(1);
            result.Records.Should().NotBeNullOrEmpty();
        }

        [Test]
        [Ignore]
        public void should_be_able_to_remove_from_blacklist()
        {
            Blacklist.Delete(1);

            var result = Blacklist.GetPaged(0, 1000, "date", "desc");

            result.Should().NotBeNull();
            result.TotalRecords.Should().Be(0);
        }
    }
}
