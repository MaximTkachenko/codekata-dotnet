﻿using FluentAssertions;
using Xunit;

namespace Core.Tests
{
    public class PathTests
    {
        [Fact]
        public void GetPath_ConnectedGraph_PathFound()
        {
            var path = new Path("a");
            path.Set("b", "c");
            path.Set("c", "a");
            path.Set("m", "a");
            path.Set("d", "b");
            path.Set("e", "d");

            string.Join("", path.GetPath("e")).Should().Be("acbde");
        }

        [Fact]
        public void GetPath_ToNotConnectedToFrom_PathNotFpund()
        {
            var path = new Path("a");
            path.Set("b", "c");
            path.Set("c", "a");
            path.Set("m", "a");
            path.Set("d", "b");

            string.Join("", path.GetPath("e")).Should().Be("");
        }

        [Fact]
        public void GetPath_ToEqualFrom_EmptyPath()
        {
            var path = new Path("a");
            path.Set("b", "c");
            path.Set("c", "a");
            path.Set("m", "a");
            path.Set("d", "b");

            string.Join("", path.GetPath("a")).Should().Be("");
        }
    }
}
