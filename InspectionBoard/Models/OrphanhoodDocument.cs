using System;
using System.Collections.Generic;

namespace InspectionBoard.Models;

public partial class OrphanhoodDocument
{
    public int IdOrphanhoodDocumentImg { get; set; }

    public byte[] OrphanhoodDocumentImg { get; set; } = null!;
}
