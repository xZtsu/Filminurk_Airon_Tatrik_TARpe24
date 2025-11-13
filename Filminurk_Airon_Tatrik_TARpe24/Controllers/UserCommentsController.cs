using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Filminurk.Models.UserComments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filminurk.Controllers
{
    public class UserCommentsController : Controller
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IUserCommentsServices _userCommentsServices;
        public UserCommentsController
            (
            FilminurkTARpe24Context context,
            IUserCommentsServices userCommentsServices
            )
        {
            _context = context;
            _userCommentsServices = userCommentsServices;
        }
        public IActionResult Index()
        {
            var result = _context.UserComments
                .Select(c => new UserCommentsIndexViewModel
                {
                    CommentID = c.CommentID,
                    CommentBody = c.CommentBody,
                    IsHarmful = (int)c.IsHarmful,
                    IsHelpful = (int)c.IsHelpful,
                    CommentCreatedAt = c.CommentCreatedAt


                }
                );
            return View(result);
        }
        [HttpGet]
        public IActionResult NewComment()
        {
            //TODO: erista kas tegemist on admini, või tavakasutajaga
            UserCommentsCreateViewModel newcomment = new();
            return View();
        }
        [HttpPost, ActionName("NewComment")]
        //Meetodile ei tohi panna allowanonymous
        public async Task<IActionResult> NewCommentPost(UserCommentsCreateViewModel newcommentVM)
        {

           // newcommentVM.CommenterUserID = "00000000-0000-0000-000000000001";
            Console.WriteLine(newcommentVM.CommenterUserID);

            if (ModelState.IsValid)
            {
                var dto = new UserCommentDTO() { } ;
                

                dto.CommentID = newcommentVM.CommentID;
                dto.CommentBody = newcommentVM.CommentBody;
                dto.CommenterUserID = newcommentVM.CommenterUserID;
                dto.CommentedScore = newcommentVM.CommentedScore;
                dto.CommentCreatedAt = newcommentVM.CommentCreatedAt;
                dto.CommentModifiedAt = newcommentVM.CommentModifiedAt;
                dto.CommentDeletedAt = newcommentVM.CommentDeletedAt;
                dto.IsHelpful = newcommentVM.IsHelpful;
                dto.IsHarmful = newcommentVM.IsHarmful;

                /*
                dto.CommentID = (Guid)newcommentVM.CommentID,
                       dto.= CommentBody = newcommentVM.CommentBody,
                       dto.= CommenterUserID = "00000000-0000-0000-000000000000",
                       dto.= CommentedScore = newcommentVM.CommentedScore,
                       dto.= CommentCreatedAt = newcommentVM.CommentCreatedAt,
                       dto.= CommentModifiedAt = newcommentVM.CommentModifiedAt,
                       dto.= CommentDeletedAt = newcommentVM.CommentDeletedAt,
                       dto.= IsHelpful = newcommentVM.IsHelpful,
                       dto.= IsHarmful = newcommentVM.IsHarmful
                */
                var result = await _userCommentsServices.NewComment(dto);
                if (result == null)
                {
                    return NotFound();
                }
                //TODO: erista ära kas tegu on admini või kasutajaga, admin tagastub admin-comments-index, kasutaja aga vastava filmi juurde
                return RedirectToAction(nameof(Index));
                //return RedirectToAction("Details", "Movies", id)
            }
            return View(newcommentVM);
        }
        [HttpGet]
        public async Task<IActionResult> DetailsAdmin(Guid id)
        {
            var requestedComment = await _userCommentsServices.DetailAsync(id);


            if (requestedComment == null) { return NotFound(); }

            var commentVM = new UserCommentsIndexViewModel();

            commentVM.CommentID = requestedComment.CommentID;
            commentVM.CommentBody = requestedComment.CommentBody;
            commentVM.CommenterUserID = requestedComment.CommenterUserID;
            commentVM.CommentedScore = requestedComment.CommentedScore;
            commentVM.CommentCreatedAt = requestedComment.CommentCreatedAt;
            commentVM.CommentModifiedAt = requestedComment.CommentModifiedAt;
            commentVM.CommentDeletedAt = requestedComment.CommentDeletedAt;
            commentVM.IsHelpful = requestedComment.IsHelpful;
            commentVM.IsHarmful = requestedComment.IsHarmful;

            return View(commentVM);
        }


    }
}
