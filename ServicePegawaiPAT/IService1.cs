using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Data.SqlClient;
using System.Text;

namespace ServicePegawaiPAT
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "Pegawai", ResponseFormat = WebMessageFormat.Json)] //untuk membuat slash, selalu relative
        List<Pegawai> GetAllPegawai(); //mendapatkan kumpulan Mahasiswa/seluruh data mahasiswa
        //string GetData(int value);

        [OperationContract]
        [WebInvoke(UriTemplate = "Pegawai/id_pegawai={id_pegawai}", ResponseFormat = WebMessageFormat.Json)] //untuk get
        Pegawai GetPegawaiByid_pegawai(string id_pegawai); //mengambil data berdasarkan nim
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Pegawai", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string CreatePegawai(Pegawai pgw);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class Pegawai
    {
        private string _nama, _id_pegawai, _jk, _agama; //_ adalah Konvensi atau kesepakatan //variabel lokal
        [DataMember(Order = 1)] //mengirim data untuk mengurutkan //
        public string nama
        {
            get { return _nama; }
            set { _nama = value; }
        }
        [DataMember(Order = 2)]
        public string id_pegawai
        {
            get { return _id_pegawai; }
            set { _id_pegawai = value; }
        }
        [DataMember(Order = 3)]
        public string jenis_kelamin
        {
            get { return _jk; }
            set { _jk = value; }
        }
        [DataMember(Order = 4)]
        public string agama
        {
            get { return _agama; }
            set { _agama = value; }
        }
    }



    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ServiceRest_20190140022_LaelaWulidaImroatusSolikha.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
