﻿// TraceLab Component Library
// Copyright © 2012-2013 SEMERU
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.ComponentModel;
using TraceLab.Components.DevelopmentKit;
using TraceLabSDK;
using TraceLabSDK.Component.Config;
using TraceLabSDK.Types;

namespace TraceLab.Components.Library.Importers.Artifacts
{
    [Component(Name = "TermDocumentMatrix Importer",
                Description = "Imports a document corpus in the form of a tab-delimited document-by-term matrix and outputs a TLArtifactsCollection",
                Author = "SEMERU; Evan Moritz",
                Version = "1.0.0.0",
                ConfigurationType = typeof(TermDocumentMatrixConfig))]
    [IOSpec(IOSpecType.Output, "Artifacts", typeof(TLArtifactsCollection))]
    [Tag("Importers.TLArtifactsCollection.From TXT")]
    public class TermDocumentMatrixImporter : BaseComponent
    {
        private TermDocumentMatrixConfig _config;

        public TermDocumentMatrixImporter(ComponentLogger log)
            : base(log)
        {
            _config = new TermDocumentMatrixConfig();
            Configuration = _config;
        }

        public override void Compute()
        {
            Workspace.Store("Artifacts", TermDocumentMatrix.Load(_config.CorpusDocument.Absolute).ToTLArtifactsCollection());
        }
    }

    public class TermDocumentMatrixConfig
    {
        [DisplayName("Document matrix")]
        [Description("Corpus file location")]
        public FilePath CorpusDocument { get; set; }
    }
}
