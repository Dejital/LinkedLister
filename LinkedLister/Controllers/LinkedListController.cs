using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using LinkedLister.Models;

namespace LinkedLister.Controllers
{
    public class LinkedListController : ApiController
    {
        private readonly ILinkedListProcessor _linkedListProcessor;

        public LinkedListController()
        {
            _linkedListProcessor = LinkedListProcessor.Instance;
        }

        // POST: api/LinkedList
        [ResponseType(typeof(LinkedListResult))]
        public IHttpActionResult PostLinkedList(ICollection<LinkedList> linkedListCollection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = _linkedListProcessor.CombineAndSortLinkedLists(linkedListCollection);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
