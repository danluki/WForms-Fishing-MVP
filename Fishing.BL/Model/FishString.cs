using Fishing.AbstractFish;
using Fishing.BL.Model.Baits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fishing.BL.Model {

    /// <summary>
    /// Name:Size% MinDeep-MaxDeep [Lure[i], Lure[i+1]...Lure[i+8]
    /// </summary>
    ///
    public class FishString {
        private readonly string _loadStr;

        public FishString(string loadStr) {
            var pattern = @".+:\d+\s\d+-\d+\s\[.+\]";
            if (Regex.IsMatch(loadStr, pattern)) {
                _loadStr = loadStr;
            }
            else {
                throw new ArgumentException("Wrong format!");
            }
        }

        public Fish GetFishByStr() {
            var regex = new Regex(@".*(?=:)");

            var fishName = regex.Match(_loadStr);
            var name = fishName.Value;

            regex = new Regex(@"\d+");

            var matches = regex.Matches(_loadStr);
            var sizeCf = Convert.ToSingle(matches[0].Value) / 100;
            var minDeep = Convert.ToInt32(matches[1].Value);
            var maxDeep = Convert.ToInt32(matches[2].Value);

            regex = new Regex(@"(?<=\[).*(?=\])");

            var match = regex.Match(_loadStr);
            var luresList = match.Value;

            var lures = luresList.Split(',');

            var baits = new HashSet<FishBait>();

            foreach (var s in lures) {
                baits.Add(FishBait.GetFishBaitByName(s));
            }

            return (from f in Fish.AllFishes where f.Key.Equals(name)
                    select Activator.CreateInstance(f.Value, minDeep, maxDeep, sizeCf, baits)
                    into targetObject select (Fish)targetObject).FirstOrDefault();
        }
    }
}