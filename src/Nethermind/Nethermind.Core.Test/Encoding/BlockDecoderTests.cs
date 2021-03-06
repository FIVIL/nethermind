﻿/*
 * Copyright (c) 2018 Demerzel Solutions Limited
 * This file is part of the Nethermind library.
 *
 * The Nethermind library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * The Nethermind library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.
 */

using System.IO;
using Nethermind.Core.Encoding;
using NUnit.Framework;

namespace Nethermind.Core.Test.Encoding
{
    [TestFixture]
    public class BlockDecoderTests
    {
        [Test]
        public void Can_do_roundtrip_null()
        {
            Rlp rlp = Rlp.Encode((Block) null);
            Block decoded = Rlp.Decode<Block>(rlp);
            Assert.IsNull(decoded);
        }
        
        [Test]
        public void Can_do_roundtrip_null_memory_stream()
        {
            using (MemoryStream stream = Rlp.BorrowStream())
            {
                Rlp.Encode(stream,(Block) null);
                Block decoded = Rlp.Decode<Block>(stream.ToArray());
                Assert.IsNull(decoded);
            }
        }
        
        [Test]
        public void Get_length_null()
        {
            BlockDecoder decoder = new BlockDecoder();
            Assert.AreEqual(1, decoder.GetLength(null, RlpBehaviors.None));
        }
    }
}