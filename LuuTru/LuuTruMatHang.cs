using DoAnMonHoc_23880108.Entity;
using Newtonsoft.Json;

namespace DoAnMonHoc_23880108.LuuTru
{
	public class LuuTruMatHang : ILuuTruMatHang
	{
		private string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
		private string fileName = "../../../Stored/DanhSachMatHang.txt";
		private string filePath = string.Empty; //Property


		public void LuuDanhSach(List<MatHang> ds)
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

		public List<MatHang> DocDanhSach()
		{
			filePath = Path.Combine(currentDirectory, fileName);
			StreamReader file = new StreamReader(filePath);
			string jsonString = file.ReadToEnd();
			var ds = JsonConvert.DeserializeObject<List<MatHang>>(jsonString);
			file.Close();
			return ds;
		}

		public void ThemMatHang(MatHang sp)
		{
			List<MatHang> ds = DocDanhSach();
			foreach (MatHang matHang in ds)
			{
				if (matHang.Ma.ToLower() == sp.Ma.ToLower())
				{
					throw new Exception("Mã mặt hàng đã tồn tại");
				}
			}
			ds.Add(sp);
			LuuDanhSach(ds);
		}

		public MatHang? DocMatHang(string mssp)
		{
			List<MatHang> ds = DocDanhSach();
			foreach (MatHang sp in ds)
			{
				if (sp.Ma.ToLower() == mssp.ToLower())
				{
					return sp;
				}
			}
			return null;
		}

		public void SuaMatHang(MatHang sp)
		{
			List<MatHang> ds = DocDanhSach();
			for (int i = 0; i < ds.Count; i++)
			{
				if (ds[i].Ma.ToLower() == sp.Ma.ToLower())
				{
					ds[i] = sp;
					LuuDanhSach(ds);
				}
			}
		}

		public void XoaMatHang(string mssp)
		{
			List<MatHang> ds = DocDanhSach();			
			for (int i = ds.Count - 1; i >= 0; i--)
			{
				if (ds[i].Ma.ToLower() == mssp.ToLower())
				{
					ds.RemoveAt(i);
				}
			}
			LuuDanhSach(ds);
		}
	}
}
