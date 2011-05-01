using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiTU_CS.Data {

    class ResultData {

        public List<int> AnswerId {
            get {
                return __AnswerId;
            }
        }

        public int StudentId {
            get {
                return __StudentId;
            }
            set {
                __StudentId = value;
            }
        }

        private List<int> __AnswerId;
        private int __StudentId;

    }

}
