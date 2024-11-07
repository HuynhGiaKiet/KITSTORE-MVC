using Project_63130599.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_63130599.DATA
{
    public class sdDanhMuc
    {

        Project_63130599Entities db = new Project_63130599Entities();
        public List<DanhMuc> LoadDanhSach()
        {
            var danhSach = db.DanhMucs.ToList();

            return danhSach;
        }

    }
}