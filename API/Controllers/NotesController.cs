using API.Errors;
using API.Helper;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specification.NoteSpec;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class NotesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NotesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<NotesDto>>> GetNotes(
            [FromQuery] NoteSpecParams notesParams
        )
        {
            var spec = new NoteSpecification(notesParams);
            var countSpec = new NoteWithFiltersForCountSpecification(notesParams);
            var totalItems = await _unitOfWork.Repository<Notes>().CountAsync(countSpec);

            var notes = await _unitOfWork.Repository<Notes>().ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<NotesDto>>(notes);

            return Ok(new Pagination<NotesDto>(
                notesParams.PageSize, notesParams.PageSize, totalItems, data
            ));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NotesDto>> GetNote(int id)
        {
            var spec = new NoteSpecification(id);

            var note = await _unitOfWork.Repository<Notes>().GetEntityWithSpec(spec);

            if (note == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Notes, NotesDto>(note);
        }
    }
}