using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAQs.Business.Services;
using FAQs.Common.Utilities;
using FAQs.Data.DTOs;
using FAQs.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAQs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        private readonly IFAQServices _faqServices;

        public FaqController(IFAQServices faqServices)
        {
            _faqServices = faqServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFaqs()
        {
            var faqs = await _faqServices.GetItems();

            var faqsDto = faqs.ConvertToDto();

            return Ok(faqsDto);
        }

        [HttpGet("{faqId:Guid}")]
        public async Task<IActionResult> GetFaqById(Guid faqId)
        {
            if (faqId == Guid.Empty)
            {
                return BadRequest("faqId can't be empty");
            }
            
            var faq = await _faqServices.GetItem(faqId);
            if (faq is null)
            {
                return NotFound($"Item with id {faqId} not found");
            }
            
            var faqDto = faq.ConvertToDto();
            
            return Ok(faqDto);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> CreateFaq([FromBody] CreateFaqDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // check language must be "vi" || "cn" || "jp"
            if (dto.Translations.Any(faqTranslationDto => !(faqTranslationDto.Language.ToLower() == "vi" || faqTranslationDto.Language.ToLower() == "cn" ||
                                                            faqTranslationDto.Language.ToLower() == "jp")))
            {
                return BadRequest("Translation's language must be \"vi\" or \"cn\" \"jp\"");
            }
            
            // check question must be unique
            var checkFaqQuestionUnique = _faqServices.GetItems().Result.FirstOrDefault(f => f.Question.ToLower() == dto.Question.ToLower());
            if (checkFaqQuestionUnique is not null)
            {
                return BadRequest("This question already exists");
            }
            
            var faqId = Guid.NewGuid();
            
            var faq = dto.ConvertToDto(faqId);

            await _faqServices.CreateItem(faq);
            
            return NoContent();
        }

        [Authorize]
        [HttpPatch("{faqId:Guid}")]
        public async Task<ActionResult> UpdateFaq(Guid faqId, CreateFaqDto dto)
        {
            if (faqId == Guid.Empty || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var faq = await _faqServices.GetItem(faqId);
            if (faq is null)
            {
                return NotFound($"FAQ with id {faqId} is not found!");
            }

            var createdTime = faq.CreatedDate;
            
            faq.Question = dto.Question;
            faq.Answer = dto.Answer;
            faq.ModifiedDate = DateTime.UtcNow;
            faq.FaqTranslations = (from faqTranslation in dto.Translations
                    select new FaqTranslation
                    {
                        Language = faqTranslation.Language,
                        Question = faqTranslation.Question,
                        Answer = faqTranslation.Answer,
                        CreatedDate = createdTime,
                        ModifiedDate = DateTime.UtcNow
                    }).ToList();

            await _faqServices.UpdateItem(faq);
            
            return NoContent();
        }
    }
}
