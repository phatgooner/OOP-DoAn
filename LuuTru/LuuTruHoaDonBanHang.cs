using DoAnMonHoc_23880108.Entity;
using Newtonsoft.Json;

namespace DoAnMonHoc_23880108.LuuTru
{
	public class LuuTruHoaDonBanHang : ILuuTruHoaDon
	{
		private string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
		private string fileName = "../../../Stored/DanhSachHoaDonBanHang.txt";
		private string filePath = string.Empty; //Property

		public void LuuDanhSach(List<HoaDon> ds)
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

		public List<HoaDon> DocDanhSach()
		{
			filePath = Path.Combine(currentDirectory, fileName);
			StreamReader file = new StreamReader(filePath);
			string jsonString = file.ReadToEnd();
			var ds = JsonConvert.DeserializeObject<List<HoaDon>>(jsonString);
			file.Close();
			return ds;
		}

		public void ThemHoaDon(HoaDon hd)
		{
			List<HoaDon> ds = DocDanhSach();
			foreach (HoaDon hoaDon in ds)
			{
				if (hoaDon.Ma.ToLower() == hd.Ma.ToLower())
				{
					throw new Exception("Mã hóa đơn đã tồn tại");
				}
			}
			ds.Add(hd);
			LuuDanhSach(ds);
		}

		public HoaDon? DocHoaDon(string ma)
		{
			List<HoaDon> ds = DocDanhSach();
			foreach (HoaDon hd in ds)
			{
				if (hd.Ma.ToLower() == ma.ToLower())
				{
					return hd;
				}
			}
			return null;
		}

		public void SuaHoaDon(HoaDon hd)
		{
			List<HoaDon> ds = DocDanhSach();
			for (int i = 0; i < ds.Count; i++)
			{
				if (ds[i].Ma.ToLower() == hd.Ma.ToLower())
				{
					ds[i] = hd;
					LuuDanhSach(ds);
				}
			}
		}

		public void XoaHoaDon(string ma)
		{
			List<HoaDon> ds = DocDanhSach();
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
