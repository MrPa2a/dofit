﻿using DofitAPI.Models;
using DofitAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DofitAPI.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsService _itemsService;

        public ItemsController(ItemsService booksService) =>
            _itemsService = booksService;

        [HttpGet]
        public async Task<List<Item>> Get() =>
            await _itemsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Item>> Get(string id)
        {
            var item = await _itemsService.GetAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Item newItem)
        {
            await _itemsService.CreateAsync(newItem);

            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Item updatedItem)
        {
            var item = await _itemsService.GetAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            updatedItem.Id = item.Id;

            await _itemsService.UpdateAsync(id, updatedItem);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _itemsService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _itemsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
