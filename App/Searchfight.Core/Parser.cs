using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
namespace Searchfight.Core
{
    public class Parser
    {
        private string[] Content;
        public bool IsValid { get; protected set; }
        public string Message { get; set; }

        
        public IReadOnlyList<string> Words { get; protected set; }
        
        public Parser(string[] inputs) {
            this.Content = inputs;
            this.Parse();
        }
        private void Parse()
        {
            this.ValidateInput();
            if (this.IsValid) {
                this.Words = ImmutableArray.Create<string>(this.Content);                
            }
        }

        private void ValidateInput() {
            this.IsValid = false;
            this.Message = "you must provide values, similar to searchfight.exe java .net";            
            if (this.Content != null && this.Content.Length > 1)
            {
                this.IsValid = true;
                this.Message = "";
            }            
        }
    }
}
