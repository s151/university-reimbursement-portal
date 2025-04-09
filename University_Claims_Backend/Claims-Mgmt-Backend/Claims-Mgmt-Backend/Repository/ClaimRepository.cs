using Claims_Mgmt_Backend.DTOs;
using Claims_Mgmt_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Claims_Mgmt_Backend.Repository
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly claimsdbContext _context;

        public ClaimRepository(claimsdbContext context)
        {
            _context = context;
        }

        public List<Claim> AllClaims()
        {
            return this._context.Claims.Include(x=>x.Member).ToList<Claim>();
        }

        public List<Claim> FilterClaims(FilterClaimDTO filter)
        {
            var result = this._context.Claims.Include(x => x.Member)
                .Where(x => x.Member.Mname.Contains(filter.Search)
                || x.Vno.Contains(filter.Search)
                || x.Status.Contains(filter.Search))
                .ToList();
            return filter.MemberId is null ? result : result.Where(x => x.Member.Id == filter.MemberId).ToList();
        }

        public Claim? GetClaim(int id)
        {
            return _context.Claims.Include(x=>x.Member).Include(x=>x.Documents).FirstOrDefault(x=>x.Id==id);
        }

        public List<Claim> MemberClaims(int id)
        {
            return this._context.Claims.Include(x=>x.Member).Where(x=>x.Memberid == id).ToList();    
        }

        public int SaveClaim(ClaimsRequestDTO dto)
        {
            
            Claim claim=new Claim
            {
                Memberid=dto.Memberid,
                ClaimAmount=dto.ClaimAmount,
                Vtype=dto.Vtype,
                Vno=dto.Vno,
                InsuranceAmount=dto.InsuranceAmount,
                Model=dto.Model,                
            };
            this._context.Claims.Add(claim);
            this._context.SaveChanges();

            if (!string.IsNullOrEmpty(dto.doctype1))
            {
                Document document = new Document
                {
                    ClaimId = claim.Id,
                    Doctype=dto.doctype1,
                    Docfile=uploadFile(dto.docFile1,claim.Id+"-1".ToString())
                };
                _context.Documents.Add(document);
            }
            if (!string.IsNullOrEmpty(dto.doctype2))
            {
                Document document = new Document
                {
                    ClaimId = claim.Id,
                    Doctype = dto.doctype2,
                    Docfile = uploadFile(dto.docFile2, claim.Id + "-2".ToString())
                };
                _context.Documents.Add(document);
            }
            if (!string.IsNullOrEmpty(dto.doctype3))
            {
                Document document = new Document
                {
                    ClaimId = claim.Id,
                    Doctype = dto.doctype3,
                    Docfile = uploadFile(dto.docFile3, claim.Id + "-3".ToString())
                };
                _context.Documents.Add(document);
            }
            _context.SaveChanges();
            return claim.Id;
        }

        public void updateClaim(UpdateClaimDTO dto)
        {
            var claim = _context.Claims.FirstOrDefault(x => x.Id == dto.ClaimId);
            if(claim is not null)
            {
                claim.FinalAmount= dto.FinalAmount;
                claim.Status    =dto.Status;
                claim.ProcessDate = dto.ProcessDate;
                claim.RejReason = dto.RejReason;
                _context.Claims.Update(claim);
                _context.SaveChanges();
            }
        }


        private string uploadFile(IFormFile? formFile,string fileNamePrefix)
        {
            var filePath = Path.Combine("wwwroot/uploads",fileNamePrefix+"-"+formFile?.FileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                formFile.CopyTo(stream);
            }
            return String.Concat("uploads/",fileNamePrefix,"-",formFile?.FileName);
        }
    }
}
