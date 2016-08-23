using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Algorithms.EntityFrameworkPivot
{
    public class PivotRow<TypeId, TypeAttr, TypeValue>
    {
        public TypeId ObjectId { get; set; }
        public IEnumerable<TypeAttr> Attributes { get; set; }
        public IEnumerable<TypeValue> Values { get; set; }

        public static DataTable GetPivotTable(List<TypeAttr> attributeNames,List<PivotRow<TypeId, TypeAttr, TypeValue>> source)
        {
            DataTable dt = new DataTable();

            DataColumn dc = new DataColumn("ID", typeof (TypeId));
            dt.Columns.Add(dc);

            // Creat the new DataColumn for each attribute 
            attributeNames.ForEach(name =>
            {
                dc = new DataColumn(name.ToString(), typeof (TypeValue));
                dt.Columns.Add(dc);
            });

            // Insert the data into the Pivot table 
            foreach (PivotRow<TypeId, TypeAttr, TypeValue> row in source)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = row.ObjectId;


                List<TypeAttr> attributes = row.Attributes.ToList();
                List<TypeValue> values = row.Values.ToList();


                // Set the value basing the attribute names. 
                for (int i = 0; i < values.Count; i++)
                {
                    dr[attributes[i].ToString()] = values[i];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }


}