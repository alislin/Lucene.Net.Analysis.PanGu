using Lucene.Net.Analysis.Core;
using PanGu.Match;
using System.IO;

using LVERSION = global::Lucene.Net.Util.LuceneVersion;

namespace Lucene.Net.Analysis.PanGu
{

    public class PanGuAnalyzer
        : Analyzer
    {

        private bool _OriginalResult = false;
        private MatchOptions _options;
        private MatchParameter _parameters;

        public PanGuAnalyzer()
        {
        }

        public PanGuAnalyzer(MatchOptions options, MatchParameter parameters)
            : base()
        {
            _options = options;
            _parameters = parameters;
        }

        /// <summary>
        /// Return original string.
        /// Does not use only segment
        /// </summary>
        /// <param name="originalResult"></param>
        public PanGuAnalyzer(bool originalResult)
        {
            _OriginalResult = originalResult;
        }

        public override TokenStreamComponents CreateComponents(string fieldName, TextReader reader)
        {
            var result = new PanGuTokenizer(reader, _OriginalResult, _options, _parameters);
            var finalStream = (TokenStream)new LowerCaseFilter(LVERSION.LUCENE_48, result);
            return new TokenStreamComponents(result, finalStream);
        }

    }


}