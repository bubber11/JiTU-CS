using System;
using System.Collections.Generic;
using System.Text;

namespace JiTU_CS.Data
{
    public class CourseData {

        public CourseData(int idIn) {
            id = idIn;
            name_internal = String.Empty;
        }

        public int id {
            get {
                return id_internal;
            }
            set {
                id_internal = value;
            }
        }

        public String name {
            get {
                return name_internal;
            }
            set {
                name_internal = value;
            }
        }

        private int id_internal;
        private String name_internal;
        
    }
}
