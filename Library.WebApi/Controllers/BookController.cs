using System;
using AutoMapper;
using Library.App.Authors.Commands.CreateAuthor;
using Library.App.Books.Commands.CreateBook;
using Library.App.Books.Commands.DeleteBook;
using Library.App.Books.Commands.UpdateBook;
using Library.App.Books.Queries.GetBookDetails;
using Library.App.Books.Queries.GetBookList;
using Library.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BookController(IMapper mapper, IMediator mediator) => (_mapper, _mediator) = (mapper, mediator);

        [HttpGet]
        public async Task<ActionResult<List<BookDetailVm>>> GetAll()
        {
            var vm = await _mediator.Send(new GetBookListQuery());
            return Ok(vm);
        }

        [HttpGet("author/{authorId}")]
        public async Task<ActionResult<List<BookDetailVm>>> GetAll(string authorId)
        {
            var vm = await _mediator.Send(new GetBookListQuery() { Id = authorId});
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailVm>> Get(string id)
        {
            var vm = await _mediator.Send(new GetBookDetailsQuery
            {
                Id = id
            });
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateBookDto createBookDto)
        {
            var command = _mapper.Map<CreateBookCommand>(createBookDto);
            var bookId = await _mediator.Send(command);
            return Ok(bookId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookDto updateBookDto)
        {
            var command = _mapper.Map<UpdateBookCommand>(updateBookDto);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteBookCommand
            {
                Id = id
            });
            return NoContent();
        }
    }
}

