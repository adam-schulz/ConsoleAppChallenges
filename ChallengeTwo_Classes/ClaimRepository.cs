using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Classes
{
    public class ClaimRepository
    {
        Queue<Claim> _queueOfClaims = new Queue<Claim>();

        public Queue<Claim> SeeAllClaims()
        {
            return _queueOfClaims;
        }

        public Claim SeeNextClaim()
        {
            return _queueOfClaims.Peek();  // Peek returns the object at the beginning of the Queue without removing it.
        } 

        public Claim ProcessNextClaim()
        {
            Claim nextClaim = _queueOfClaims.Dequeue();  // Dequeue removes and returns the object at the beginning of the Queue.
            return nextClaim;
        }

        public void AddNewClaim(Claim newClaim)
        {
            _queueOfClaims.Enqueue(newClaim);   // Enqueue adds an object to the end of the Queue.
        }

        public int GetNumberOfClaims()
        {
            return _queueOfClaims.Count;
        }
    }
}
