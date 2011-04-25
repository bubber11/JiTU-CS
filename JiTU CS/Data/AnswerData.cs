using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiTU_CS.Data {
    class AnswerData {

        public AnswerData(int idIn) {
            id_internal = idIn;
            correct_internal = false;
            text_internal = String.Empty;
        }

        public bool correct {
            get {
                return correct_internal;
            }
            set {
                correct_internal = value;
            }
        }

        public int id {
            get {
                return id_internal;
            }
            set {
                id_internal = value;
            }
        }

        public String text {
            get {
                return text_internal;
            }
            set {
                text_internal = value;
            }
        }

        private String text_internal;
        private int id_internal;
        private bool correct_internal;

    }
}
