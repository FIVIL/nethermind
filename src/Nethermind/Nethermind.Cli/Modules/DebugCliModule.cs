/*
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

namespace Nethermind.Cli.Modules
{
    [CliModule]
    public class DebugCliModule : CliModuleBase
    {
        [CliFunction("debug", "traceBlock")]
        public string TraceBlock(string rlp)
        {
            return NodeManager.Post("debug_traceBlock", rlp).Result;
        }
        
        [CliFunction("debug", "config")]
        public string GetConfigValue(string category, string name)
        {
            return NodeManager.Post<string>("debug_getConfigValue", category, name).Result;
        }

        public DebugCliModule(ICliEngine cliEngine, INodeManager nodeManager) : base(cliEngine, nodeManager)
        {
        }
    }
}