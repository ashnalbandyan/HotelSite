using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelSite.Models;

namespace HotelSite.Controllers
{
    public class OrderRoomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Check( OrderRoom order)
        {
            var result = int.Parse(order.RoomType.ToString());
            order.Result = result;
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        // GET: OrderRooms
        public ActionResult Index()
        {
            return View(db.OrderRooms.ToList());
        }

        // GET: OrderRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRoom orderRoom = db.OrderRooms.Find(id);
            if (orderRoom == null)
            {
                return HttpNotFound();
            }
            int roomtype = (int)orderRoom.RoomType;
            int roomcount = (int)orderRoom.RoomsCount;
            int guests = (int)orderRoom.GuestsCount;
            int result = roomtype + roomcount + guests;
            orderRoom.Result = result;
            db.SaveChanges();

            return View(orderRoom);
        }

        // GET: OrderRooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoomType,RoomsCount,GuestsCount")] OrderRoom orderRoom)
        {
            if (ModelState.IsValid)
            {
                db.OrderRooms.Add(orderRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderRoom);
        }

        // GET: OrderRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRoom orderRoom = db.OrderRooms.Find(id);
            if (orderRoom == null)
            {
                return HttpNotFound();
            }
            return View(orderRoom);
        }

        // POST: OrderRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoomType,RoomsCount,GuestsCount")] OrderRoom orderRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderRoom);
        }

        // GET: OrderRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRoom orderRoom = db.OrderRooms.Find(id);
            if (orderRoom == null)
            {
                return HttpNotFound();
            }
            return View(orderRoom);
        }

        // POST: OrderRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderRoom orderRoom = db.OrderRooms.Find(id);
            db.OrderRooms.Remove(orderRoom);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
