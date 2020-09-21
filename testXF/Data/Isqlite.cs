using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace testXF.Data
{
    public interface Isqlite
    {
        SQLiteConnection GetConnection();
    }
}
