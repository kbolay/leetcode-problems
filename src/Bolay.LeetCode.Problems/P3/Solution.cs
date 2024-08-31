using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolay.LeetCode.Problems.P3
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int result = s.Length > 0 ? 1 : 0;

            int inputLength = s.Length;
            int halfLength = (s.Length / 2) + (s.Length % 2);

            var groupedSymbolIndices = s.Select((Symbol, Index) => new { Symbol = Symbol, Index = Index })
                .GroupBy(x => x.Symbol);

            // is there more than 1 symbol
            if(groupedSymbolIndices.Count() > 1) 
            {
                // are there any duplicate symbols?
                var duplicateSymbols = groupedSymbolIndices.Where(x => x.Count() > 1);
                if(duplicateSymbols.Any())
                {
                    // find largest gaps between duplicate symbols.
                    // get that substring, and check for any duplicates within that
                    // if any length without duplicates within it is greater than 1/2 of the total length stop
                    foreach(var symbolIndices in duplicateSymbols.OrderBy(x => x.Min(y => y.Index)))
                    {
                        var orderedSymbolIndices = symbolIndices.OrderBy(x => x.Index);
                        for(int i = 0; i < orderedSymbolIndices.Count(); i++)
                        {
                            int substringStart = 0;
                            int nextIndexOfSymbol = orderedSymbolIndices.Count() > i+1 ? orderedSymbolIndices.ElementAt(i+1).Index : inputLength;
                            if(i > 0)
                            {
                                var firstIndex = orderedSymbolIndices.ElementAt(i).Index;    
                            }
                            
                            var substringLength = nextIndexOfSymbol - substringStart + 1;
                            if(result < substringLength)
                            {
                                var substring = s.Substring(substringStart, substringLength - 1);
                                var subStringResult = LengthOfLongestSubstring(substring);
                                if(subStringResult > result)
                                {
                                    result = subStringResult;
                                }
                            }
                            
                            if(result >= halfLength)
                            {
                                break;
                            }
                        }
                    } // end foreach
                }
                else
                {
                    result = s.Length;
                } // end if
            } // end if

            return result;
        } // end method
    } // end class
} // end namespace