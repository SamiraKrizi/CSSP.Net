using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CbcSelfServicePortal.Models
{

    public enum InjuryReportType : Byte
    {
        EngineersReport = 1,
        MedicalReport = 2
    }
    public enum InvoicesType : Byte
    {
        CarHireInvoice = 1,
        TowingInvoice = 2,
        RepairInvoice = 3,
        EngineersInvoice = 4,
        DoctorsInvoice = 5,
        OtherInvoice = 6,
    }
    public enum OtherType : Byte
    {
        AccidentReportForm = 1,
        AgreedStatementOfFacts = 2,
        InsuredStatement = 3,
        LegalDocuments = 4,
        RepairCompanyQuotation = 5,
        ReleaseForm = 6,
        WitnessStatement = 7,
        Other = 8,
    }

    public class Documents
    {
        [Key]
        public int ID { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public byte[] File { get; set; }


    }
}
