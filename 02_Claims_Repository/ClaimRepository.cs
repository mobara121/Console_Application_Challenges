using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repository
{
    public class ClaimRepository
    {
        //field to hold all list data
        private List<Claim> _listOfContent = new List<Claim>(); 
        //Create
        public void AddClaimList(Claim content)
        {
            _listOfContent.Add(content);
        }

        //Read
        public List<Claim> GetClaimList()
        {
            return _listOfContent;
        }

        //Update
        public bool UpdateExistingContent(int originalClaimId, Claim newContent)
        {
            Claim oldContent = GetContentByClaimId(originalClaimId);
            if (oldContent != null)
            {
                oldContent.ClaimId = newContent.ClaimId;
                oldContent.ClaimType = newContent.ClaimType;
                oldContent.Description = newContent.Description;
                oldContent.ClaimAmount = newContent.ClaimAmount;
                oldContent.DateOfIncident = newContent.DateOfIncident;
                oldContent.DateOfClaim = newContent.DateOfClaim;
                oldContent.IsValid = newContent.IsValid;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete a claim from List by identifing with its claim ID
        public bool RemoveContenetFromList(int claimId)
        {
            Claim content = GetContentByClaimId(claimId);
            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfContent.Count;
            _listOfContent.Remove(content);
            if (initialCount > _listOfContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper for Update/Delete
        public Claim GetContentByClaimId(int claimId)
        {
            foreach (Claim content in _listOfContent)
            {
                if (content.ClaimId == claimId)
                {
                    return content;
                }
            }
            return null;
        }
    }
}
