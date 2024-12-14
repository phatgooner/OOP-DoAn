using DoAnMonHoc_23880108.Entity;
using Newtonsoft.Json;

namespace DoAnMonHoc_23880108.LuuTru
{
	public class LuuTruLoaiHang : ILuuTruLoaiHang
	{
		private string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
		private string fileName = "../../../Stored/DanhSachLoaiHang.txt";
		private string filePath = string.Empty; //Property

		public void LuuDanhSach(List<LoaiHang> ds)
		{
			filePath = Path.Combine(currentDirectory, fileName);
			string jsonString = JsonConvert.SerializeObject(ds);
			StreamWriter file = new StreamWriter(filePath);
			if (ds == null)
			{
				file.Write("[]");
			}
			else
			{
				file.Write(jsonString);
			}
			file.Close();
		}

		public List<LoaiHang> DocDanhSach()
		{
			filePath = Path.Combine(currentDirectory, fileName);
			StreamReader file = new StreamReader(filePath);
			string jsonString = file.ReadToEnd();
			var ds = JsonConvert.DeserializeObject<List<LoaiHang>>(jsonString);
			file.Close();
			return ds;
		}

		public void ThemLoaiHang(LoaiHang h)
		{
			List<LoaiHang> ds = DocDanhSach();
			foreach (LoaiHang lh in ds)
			{
				if (lh.Ten.ToLower() == h.Ten.ToLower() || lh.Ma.ToLower() == h.Ma.ToLower())
				{
					throw new Exception("Loại hàng này đã tồn tại!");
				}
			}
			ds.Add(h);
			LuuDanhSach(ds);
		}

		public LoaiHang? DocLoaiHang(string ma)
		{
			List<LoaiHang> ds = DocDanhSach();
			foreach (LoaiHang lh in ds)
			{
				if (lh.Ma.ToLower() == ma.ToLower())
				{
					return lh;
				}
			}
			return null;
		}

		public void SuaLoaiHang(LoaiHang lh)
		{
			List<LoaiHang> ds = DocDanhSach();
			foreach (LoaiHang h  in ds)
			{
				if (h.Ten.ToLower() == lh.Ten.ToLower())
				{
					throw new Exception("Loại hàng này đã tồn tại!");
				}	
			}	
			for (int i = 0; i < ds.Count; i++)
			{
				if (ds[i].Ma.ToLower() == lh.Ma.ToLower())
				{
					ds[i] = lh;
					LuuDanhSach(ds);
				}
			}
		}

		public void XoaLoaiHang(string ma)
		{
			List<LoaiHang> ds = DocDanhSach();
			for (int i = ds.Count - 1; i >= 0; i--)
			{
				if (ds[i].Ma.ToLower() == ma.ToLower())
				{
					ds.RemoveAt(i);
				}
			}
			LuuDanhSach(ds);
		}
	}
}
