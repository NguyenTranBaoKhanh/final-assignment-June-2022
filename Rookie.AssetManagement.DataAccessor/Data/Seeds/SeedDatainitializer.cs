using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.DataAccessor.Data.Seeds
{
    public static class SeedDatainitializer
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location()
                {
                    LocationID = "HN",
                    LocationName = "Ha Noi"
                },
                 new Location()
                 {
                     LocationID = "HCM",
                     LocationName = "Ho Chi Minh"
                 }
           );

            modelBuilder.Entity<Category>().HasData(
                 new Category()
                 {
                     CategoryID = "LA",
                     CategoryName = "Laptop",
                 },
                  new Category()
                  {
                      CategoryID = "MO",
                      CategoryName = "Monitor"
                  },
                  new Category()
                  {
                      CategoryID = "PC",
                      CategoryName = "Personal Computer"
                  }
            );

            //AssetCode: 10 characters: prefix CategoryId + (00000 + order)
            // var jsonAssetData = "[{\"AssetCode\":\"LA000001\",\"AssetName\":\"Laptop Apple MacBook Pro M1\",\"Specification\":\"Apple M1, RAM 8GB, SSD 256GB\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000002\",\"AssetName\":\"Laptop Apple MacBook Pro M1\",\"Specification\":\"Apple M1, RAM 8GB, SSD 256GB\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000003\",\"AssetName\":\"Laptop Apple MacBook Pro M1\",\"Specification\":\"Apple M1, RAM 8GB, SSD 256GB\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000004\",\"AssetName\":\"Laptop Dell XPS 13 9310\",\"Specification\":\"Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000005\",\"AssetName\":\"Laptop Dell XPS 13 9310\",\"Specification\":\"Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000006\",\"AssetName\":\"Laptop Dell XPS 13 9310\",\"Specification\":\"Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":5,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000007\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000008\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000009\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000010\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000011\",\"AssetName\":\"Laptop Apple MacBook Pro M1\",\"Specification\":\"Apple M1, RAM 8GB, SSD 256GB\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000012\",\"AssetName\":\"Laptop Apple MacBook Pro M1\",\"Specification\":\"Apple M1, RAM 8GB, SSD 256GB\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":2,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000013\",\"AssetName\":\"Laptop Apple MacBook Pro M1\",\"Specification\":\"Apple M1, RAM 8GB, SSD 256GB\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000014\",\"AssetName\":\"Laptop Dell XPS 13 9310\",\"Specification\":\"Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000015\",\"AssetName\":\"Laptop Dell XPS 13 9310\",\"Specification\":\"Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000016\",\"AssetName\":\"Laptop Dell XPS 13 9310\",\"Specification\":\"Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":5,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000017\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000018\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000019\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":2,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000020\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000001\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":3,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000002\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000003\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000004\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000005\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000006\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m2\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":5,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000007\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m3\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000008\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m4\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000009\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m5\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000010\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m6\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000011\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":3,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000012\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000013\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000014\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000015\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000016\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m2\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":5,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000017\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m3\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000018\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m4\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000019\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m5\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000020\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m6\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000001\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000002\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000003\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":5,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000004\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000005\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000006\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000007\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":5,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000008\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000009\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000010\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000011\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000012\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000013\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":5,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000014\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000015\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000016\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000017\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":5,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000018\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000019\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000020\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-01\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HN\"}]";

            var jsonAssetData = "[{\"AssetCode\":\"PC000001\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000002\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000003\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000004\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000005\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000006\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000007\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000008\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000009\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000010\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"PC000011\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000012\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000013\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000014\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000015\",\"AssetName\":\"Dell OptiPlex 3050 Micro\",\"Specification\":\"CPU: 7th Generation Intel Core i3-7100T, Graphics: Intel HD Graphics, RAM: 4GB, Storage: 500GB HDD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000016\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000017\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000018\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000019\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"PC000020\",\"AssetName\":\"Apple iMac Pro\",\"Specification\":\"CPU: Intel Xeon W, Graphics: AMD Vega 56, Vega 64RAM: 32GB, 64GBStorage: 1TB SSD\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"PC\",\"AssetState\":2,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000001\",\"AssetName\":\"Laptop Apple MacBook Pro M1\",\"Specification\":\"Apple M1, RAM 8GB, SSD 256GB\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000002\",\"AssetName\":\"Laptop Apple MacBook Pro M1\",\"Specification\":\"Apple M1, RAM 8GB, SSD 256GB\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000003\",\"AssetName\":\"Laptop Apple MacBook Pro M1\",\"Specification\":\"Apple M1, RAM 8GB, SSD 256GB\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000004\",\"AssetName\":\"Laptop Dell XPS 13 9310\",\"Specification\":\"Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000005\",\"AssetName\":\"Laptop Dell XPS 13 9310\",\"Specification\":\"Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000006\",\"AssetName\":\"Laptop Dell XPS 13 9310\",\"Specification\":\"Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":5,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000007\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000008\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000009\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000010\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"LA000011\",\"AssetName\":\"Laptop Apple MacBook Pro M1\",\"Specification\":\"Apple M1, RAM 8GB, SSD 256GB\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":2,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000012\",\"AssetName\":\"Laptop Apple MacBook Pro M1\",\"Specification\":\"Apple M1, RAM 8GB, SSD 256GB\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":2,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000013\",\"AssetName\":\"Laptop Apple MacBook Pro M1\",\"Specification\":\"Apple M1, RAM 8GB, SSD 256GB\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":2,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000014\",\"AssetName\":\"Laptop Dell XPS 13 9310\",\"Specification\":\"Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":2,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000015\",\"AssetName\":\"Laptop Dell XPS 13 9310\",\"Specification\":\"Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000016\",\"AssetName\":\"Laptop Dell XPS 13 9310\",\"Specification\":\"Intel Core i7 Tiger Lake 1165G7, RAM 16GB LPDDR4X, SSD 1 TB M.2 PCIe\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":5,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000017\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000018\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000019\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":2,\"LocationID\":\"HN\"},{\"AssetCode\":\"LA000020\",\"AssetName\":\"Laptop HP Pavilion 15\",\"Specification\":\"Intel Core i5 Tiger Lake 1135G7,  RAM 8GB DDR4, SSD 512 GB NVMe PCIe\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"LA\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000001\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000002\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000003\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000004\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000005\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000006\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m2\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000007\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m3\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000008\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m4\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":2,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000009\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m5\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000010\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m6\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HCM\"},{\"AssetCode\":\"MO000011\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":3,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000012\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000013\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000014\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000015\",\"AssetName\":\"Monitor Dell UltraSharp\",\"Specification\":\"4K, QHD & ultra-high-definition (UHD) monitors\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000016\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m2\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":5,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000017\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m3\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000018\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m4\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000019\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m5\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"},{\"AssetCode\":\"MO000020\",\"AssetName\":\"Asus Designo Curve\",\"Specification\":\"Resolution: 3,840 x 1,600px. Brightness: 300 cd/m6\",\"InstalledDay\":\"2021-08-17\",\"CategoryID\":\"MO\",\"AssetState\":1,\"LocationID\":\"HN\"}]";

            IList<Asset> assetData = JsonConvert.DeserializeObject<IList<Asset>>(jsonAssetData);
            modelBuilder.Entity<Asset>().HasData(
                    assetData.ToArray()
                );

            modelBuilder.Entity<Assignment>().HasData(
                new Assignment()
                {
                    Id = 1,
                    AssignmentState = AssignmentState.Waiting,
                    AssignedByUserId = 1,
                    AssignedToUserId = 2,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "LA000001"
                },
                new Assignment()
                {
                    Id = 2,
                    AssignmentState = AssignmentState.Accepted,
                    AssignedByUserId = 1,
                    AssignedToUserId = 2,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "LA000002"
                },
                new Assignment()
                {
                    Id = 3,
                    AssignmentState = AssignmentState.Accepted,
                    AssignedByUserId = 1,
                    AssignedToUserId = 2,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "LA000003"
                },
                new Assignment()
                {
                    Id = 4,
                    AssignmentState = AssignmentState.Waiting,
                    AssignedByUserId = 1,
                    AssignedToUserId = 2,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "LA000004"
                },
                new Assignment()
                {
                    Id = 5,
                    AssignmentState = AssignmentState.Waiting,
                    AssignedByUserId = 1,
                    AssignedToUserId = 3,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "LA000005"
                },
                new Assignment()
                {
                    Id = 6,
                    AssignmentState = AssignmentState.Waiting,
                    AssignedByUserId = 1,
                    AssignedToUserId = 3,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "MO000001"
                },
                new Assignment()
                {
                    Id = 7,
                    AssignmentState = AssignmentState.Accepted,
                    AssignedByUserId = 1,
                    AssignedToUserId = 3,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "MO000002"
                },
                new Assignment()
                {
                    Id = 8,
                    AssignmentState = AssignmentState.Waiting,
                    AssignedByUserId = 1,
                    AssignedToUserId = 3,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "MO000003"
                },
                new Assignment()
                {
                    Id = 9,
                    AssignmentState = AssignmentState.Waiting,
                    AssignedByUserId = 1,
                    AssignedToUserId = 3,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "MO000004"
                },
                new Assignment()
                {
                    Id = 10,
                    AssignmentState = AssignmentState.Waiting,
                    AssignedByUserId = 1,
                    AssignedToUserId = 3,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "MO000005"
                },
                new Assignment()
                {
                    Id = 11,
                    AssignmentState = AssignmentState.Waiting,
                    AssignedByUserId = 4,
                    AssignedToUserId = 2,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "PC000001"
                },
                new Assignment()
                {
                    Id = 12,
                    AssignmentState = AssignmentState.Waiting,
                    AssignedByUserId = 1,
                    AssignedToUserId = 4,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "PC000002"
                },
                new Assignment()
                {
                    Id = 13,
                    AssignmentState = AssignmentState.Waiting,
                    AssignedByUserId = 1,
                    AssignedToUserId = 4,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "PC000003"
                },
                new Assignment()
                {
                    Id = 14,
                    AssignmentState = AssignmentState.Waiting,
                    AssignedByUserId = 1,
                    AssignedToUserId = 4,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "PC000004"
                },
                new Assignment()
                {
                    Id = 15,
                    AssignmentState = AssignmentState.Waiting,
                    AssignedByUserId = 1,
                    AssignedToUserId = 4,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "PC000005"
                },
                new Assignment()
                {
                    Id = 16,
                    AssignmentState = AssignmentState.Waiting,
                    AssignedByUserId = 1,
                    AssignedToUserId = 4,
                    AssignedDate = DateTime.Now.AddDays(-1),
                    AssetCode = "PC000006"
                }
            );

            modelBuilder.Entity<Request>().HasData(
                new Request()
                {
                    Id = 1,
                    RequestedUserId = 8,
                    AssignmentId = 1
                },
                new Request()
                {
                    Id = 2,
                    RequestedUserId = 9,
                    AssignmentId = 6
                }
            );

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "thongnh",
                    NormalizedUserName = "thongnh",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1001",
                    FirstName = "Thong",
                    LastName = "Nguyen Hoang",
                    Gender = "F",
                    IsLogged = true,
                    LocationID = "HCM",
                    DateOfBirth = DateTime.Parse("1989-08-27"),
                    JoinedDate = DateTime.Parse("2015-05-27"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7WE4A7DTOM5DETPA35OHKTOZMMYP"
                },
                new User
                {
                    Id = 2,
                    UserName = "canhhm",
                    NormalizedUserName = "canhhm",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1002",
                    FirstName = "Canh",
                    LastName = "Ho Minh",
                    Gender = "M",
                    IsLogged = false,
                    LocationID = "HCM",
                    DateOfBirth = DateTime.Parse("1983-01-22"),
                    JoinedDate = DateTime.Parse("2018-05-19"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7NG4A7RTOM5DETPA35OHKTOZMMYP"
                },
                new User
                {
                    Id = 3,
                    UserName = "khanhntb",
                    NormalizedUserName = "khanhntb",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1003",
                    FirstName = "Khanh",
                    LastName = "Nguyen Tran Bao",
                    Gender = "F",
                    IsLogged = false,
                    LocationID = "HN",
                    DateOfBirth = DateTime.Parse("1987-02-11"),
                    JoinedDate = DateTime.Parse("2020-12-17"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7NG4A7DTYM5DETPA35OHKTOZMMYP"
                },
                new User
                {
                    Id = 4,
                    UserName = "sangnv",
                    NormalizedUserName = "sangnv",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1005",
                    FirstName = "Sang",
                    LastName = "Nguyen Vinh",
                    Gender = "F",
                    IsLogged = false,
                    LocationID = "HN",
                    DateOfBirth = DateTime.Parse("1983-02-09"),
                    JoinedDate = DateTime.Parse("2018-04-14"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7NG4A7DTOJ5DETPA35OHKTOZMMYP"
                },
                new User
                {
                    Id = 5,
                    UserName = "nhattm",
                    NormalizedUserName = "nhattm",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1006",
                    FirstName = "Nhut",
                    LastName = "Tran Minh",
                    Gender = "M",
                    IsLogged = true,
                    LocationID = "HN",
                    DateOfBirth = DateTime.Parse("1980-08-11"),
                    JoinedDate = DateTime.Parse("2020-08-31"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7NG4R7DTOM5DETPA35OHKTOZMMYP"
                },
                new User
                {
                    Id = 6,
                    UserName = "Vannng",
                    NormalizedUserName = "vannng",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1007",
                    FirstName = "Van",
                    LastName = "Nguyen Ngoc Gia",
                    Gender = "F",
                    IsLogged = true,
                    LocationID = "HN",
                    DateOfBirth = DateTime.Parse("1987-03-31"),
                    JoinedDate = DateTime.Parse("2016-04-03"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7NG4A7DTOM5DHTPA35OHKTOZMMYP"
                },
                new User
                {
                    Id = 7,
                    UserName = "thangnv",
                    NormalizedUserName = "thangnv",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1008",
                    FirstName = "Thang",
                    LastName = "Nguyen Viet",
                    Gender = "F",
                    IsLogged = false,
                    LocationID = "HN",
                    DateOfBirth = DateTime.Parse("1987-03-31"),
                    JoinedDate = DateTime.Parse("2016-04-03"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7NG4A7DTOM5DETPA35OMKTOZMMYP"
                },
                new User
                {
                    Id = 8,
                    UserName = "toanlh",
                    NormalizedUserName = "toanlh",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1009",
                    FirstName = "Toan",
                    LastName = "Le Hang",
                    Gender = "M",
                    IsLogged = false,
                    LocationID = "HCM",
                    DateOfBirth = DateTime.Parse("1984-12-30"),
                    JoinedDate = DateTime.Parse("2017-04-25"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7NG4A7DTOM5DETPA35OHKTOZBMYP"
                },
                new User
                {
                    Id = 9,
                    UserName = "quybd",
                    NormalizedUserName = "quybd",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1010",
                    FirstName = "Quy",
                    LastName = "Bui Duy",
                    Gender = "M",
                    IsLogged = false,
                    LocationID = "HCM",
                    DateOfBirth = DateTime.Parse("1981-06-26"),
                    JoinedDate = DateTime.Parse("2017-05-30"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7NG4A7DTOM5DETPA35OHKTOZMMYP"
                },
                new User
                {
                    Id = 10,
                    UserName = "phuongvh",
                    NormalizedUserName = "phuongvh",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1011",
                    FirstName = "Phuong",
                    LastName = "Vo Hoang",
                    Gender = "F",
                    IsLogged = false,
                    LocationID = "HCM",
                    DateOfBirth = DateTime.Parse("1986-10-14"),
                    JoinedDate = DateTime.Parse("2018-11-21"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7NG4A7DTOM5DETPA35OHKTOWMMYP"
                }
               );

            modelBuilder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole<int>
                {
                    Id = 2,
                    Name = "Staff",
                    NormalizedName = "STAFF"
                });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    UserId = 1,
                    RoleId = 1,
                },
                new IdentityUserRole<int>
                {
                    UserId = 2,
                    RoleId = 1,
                },
                new IdentityUserRole<int>
                {
                    UserId = 3,
                    RoleId = 2,
                },
                new IdentityUserRole<int>
                {
                    UserId = 4,
                    RoleId = 2,
                },
                new IdentityUserRole<int>
                {
                    UserId = 5,
                    RoleId = 2,
                },
                new IdentityUserRole<int>
                {
                    UserId = 6,
                    RoleId = 2,
                },
                new IdentityUserRole<int>
                {
                    UserId = 7,
                    RoleId = 2,
                },
                new IdentityUserRole<int>
                {
                    UserId = 8,
                    RoleId = 2,
                },
                new IdentityUserRole<int>
                {
                    UserId = 9,
                    RoleId = 2,
                },
                new IdentityUserRole<int>
                {
                    UserId = 10,
                    RoleId = 2,
                }
                );

        }
    }
}
