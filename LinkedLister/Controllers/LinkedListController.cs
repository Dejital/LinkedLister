using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using LinkedLister.Models;

namespace LinkedLister.Controllers
{
    public class LinkedListController : ApiController
    {
        // POST: api/LinkedList
        [ResponseType(typeof(ICollection<LinkedList>))]
        public IHttpActionResult PostLinkedList(ICollection<LinkedList> linkedListCollection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }
    }
}
