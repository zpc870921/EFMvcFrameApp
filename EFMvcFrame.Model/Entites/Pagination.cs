using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EFMvcFrame.Model.Entites
{
    [DataContract]
    public class Pagination
    {
         private int pageIndex;
        public Pagination(int pageIndex)
        {
            this.pageIndex = pageIndex;
            this.PageSize = 10;
        }

        public Pagination()
            : this(1)
        {


        }

        /// <summary>
        /// 当前页
        /// </summary>
        [DataMember]
        public int PageIndex {
            get
            {
                if (this.pageIndex <= 0)
                {
                    this.pageIndex = 1;
                }
                return this.pageIndex;
            }
            set
            {
                this.pageIndex = value;
            }
        }

        /// <summary>
        /// 每页大小
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }


        /// <summary>
        /// 总条目数
        /// </summary>
        [DataMember]
        public int TotalItem { get; set; }


        
        public int Start
        {

            get
            {
                
                return (PageIndex - 1) * PageSize;
            }
        }


        
        public int PageCount {
            get
            {
                return TotalItem > 0
                        ? (int)Math.Ceiling(TotalItem / (double)PageSize)
                        : 0;
            }
        }
    }
}
