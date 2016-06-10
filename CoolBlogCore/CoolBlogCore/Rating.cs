using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{

    public class Rating
    {
       
        public int VotesUp { get; private set; }

      
        public int VotesDown { get; private set; }

        public int Sum { get; private set; }
        public Rating(int votesUp, int votesDown)
        {
            VotesUp = votesUp;
            VotesDown = votesDown;
            SumUpdate();
            
        }
       
        private void SumUpdate()
        {
            Sum = VotesUp - VotesDown;
        }
        public void UpVote() 
        {
            VotesUp += 1;
            SumUpdate();
        }
        public void DownVote()
        {
            VotesDown += 1;
            SumUpdate();
        }
    }
}
