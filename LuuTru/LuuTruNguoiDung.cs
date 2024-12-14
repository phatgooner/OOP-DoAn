using DoAnMonHoc_23880108.Entity;
using Newtonsoft.Json;

namespace DoAnMonHoc_23880108.LuuTru
{
	public class LuuTruNguoiDung : ILuuTruNguoiDung
	{
		private string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
		private string fileName = "../../../Stored/DanhSachNguoiDung.txt";
		private string filePath = string.Empty; //Property

		public void LuuDanhSachNguoiDung(List<NguoiDung> ds)
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

		public List<NguoiDung> DocDanhSachNguoiDung()
		{
			filePath = Path.Combine(currentDirectory, fileName);
			StreamReader file = new StreamReader(filePath);
			string jsonString = file.ReadToEnd();
			var ds = JsonConvert.DeserializeObject<List<NguoiDung>>(jsonString);
			file.Close();
			return ds;
		}

		public void ThemNguoiDung(NguoiDung user)
		{
			LuuDanhSachNguoiDung(DocDanhSachNguoiDung());
			var ds = DocDanhSachNguoiDung();
			ds.Add(user);
			LuuDanhSachNguoiDung(ds);
		}				
	}
}
