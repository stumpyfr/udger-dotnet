﻿/*
  UdgerParser - Local parser lib
  
  UdgerParser class parses useragent strings based on a database downloaded from udger.com
 
 
  author     The Udger.com Team (info@udger.com)
  copyright  Copyright (c) Udger s.r.o.
  license    GNU Lesser General Public License
  link       https://udger.com/products/local_parser
 */

using System;

namespace Udger.Parser
{
    class UdgerSqlQuery
    {
        public static readonly String SQL_CRAWLER =
        "SELECT " +
            "NULL AS client_id, " +
            "NULL AS class_id, " +
            "'Crawler' AS ua_class, " +
            "'crawler' AS ua_class_code, " +
            "name AS ua, " +
            "NULL AS ua_engine, " +
            "ver AS ua_version, " +
            "ver_major AS ua_version_major, " +
            "last_seen AS crawler_last_seen, " +
            "respect_robotstxt AS crawler_respect_robotstxt, " +
            "crawler_classification AS crawler_category, " +
            "crawler_classification_code AS crawler_category_code, " +
            "NULL AS ua_uptodate_current_version, " +
            "family AS ua_family, " +
            "family_code AS ua_family_code, " +
            "family_homepage AS ua_family_homepage, " +
            "family_icon AS ua_family_icon, " +
            "NULL AS ua_family_icon_big, " +
            "vendor AS ua_family_vendor, " +
            "vendor_code AS ua_family_vendor_code, " +
            "vendor_homepage AS ua_family_vendor_homepage, " +
            "'https://udger.com/resources/ua-list/bot-detail?bot=' || REPLACE(family, ' ', '%20') || '#id' || udger_crawler_list.id AS ua_family_info_url " +
        "FROM " +
            "udger_crawler_list " +
        "LEFT JOIN " +
            "udger_crawler_class ON udger_crawler_class.id = udger_crawler_list.class_id " +
        "WHERE " +
            "ua_string = '{0}'";

    public static readonly String SQL_CLIENT =
        "SELECT " +
            "ur.rowid, " +
            "client_id AS client_id, " +
            "class_id AS class_id, " +
            "client_classification AS ua_class, " +
            "client_classification_code AS ua_class_code, " +
            "name AS ua, " +
            "engine AS ua_engine, " +
            "NULL AS ua_version, " +
            "NULL AS ua_version_major, " +
            "NULL AS crawler_last_seen, " +
            "NULL AS crawler_respect_robotstxt, " +
            "NULL AS crawler_category, " +
            "NULL AS crawler_category_code, " +
            "uptodate_current_version AS ua_uptodate_current_version, " +
            "name AS ua_family, " +
            "name_code AS ua_family_code, " +
            "homepage AS ua_family_homepage, " +
            "icon AS ua_family_icon, " +
            "icon_big AS ua_family_icon_big, " +
            "vendor AS ua_family_vendor, " +
            "vendor_code AS ua_family_vendor_code, " +
            "vendor_homepage AS ua_family_vendor_homepage, " +
            "regstring, " +
            "'https://udger.com/resources/ua-list/browser-detail?browser=' || REPLACE(name, ' ', '%20') AS ua_family_info_url " +
        "FROM " +
            "udger_client_regex ur " +
        "JOIN " +
            "udger_client_list ON udger_client_list.id = ur.client_id " +
        "JOIN " +
            "udger_client_class ON udger_client_class.id = udger_client_list.class_id " +
        "WHERE " +
            "ur.rowid={0}";

    private static readonly String OS_COLUMNS =
            "family AS os_family, " +
            "family_code AS os_family_code, " +
            "name AS os, " +
            "name_code AS os_code, " +
            "homepage AS os_home_page, " +
            "icon AS os_icon, " +
            "icon_big AS os_icon_big, " +
            "vendor AS os_family_vendor, " +
            "vendor_code AS os_family_vendor_code, " +
            "vendor_homepage AS os_family_vedor_homepage, " +
            "'https://udger.com/resources/ua-list/os-detail?os=' || REPLACE(name, ' ', '%20') AS os_info_url ";

    public static readonly String SQL_OS =
        "SELECT " +
            "ur.rowid, " +
            OS_COLUMNS +
        "FROM " +
            "udger_os_regex ur " +
        "JOIN " +
            "udger_os_list ON udger_os_list.id = ur.os_id " +
        "WHERE " +
            "ur.rowid={0}";

    public static readonly String SQL_CLIENT_OS =
        "SELECT " +
            OS_COLUMNS +
        "FROM " +
            "udger_client_os_relation " +
        "JOIN " +
            "udger_os_list ON udger_os_list.id = udger_client_os_relation.os_id " +
        "WHERE " +
            "client_id = {0}";

    private static readonly String DEVICE_COLUMNS =
            "name AS device_class, " +
            "name_code AS device_class_code, " +
            "icon AS device_class_icon, " +
            "icon_big AS device_class_icon_big, " +
            "'https://udger.com/resources/ua-list/device-detail?device=' || REPLACE(name, ' ', '%20') AS device_class_info_url ";

    public static readonly String SQL_DEVICE =
        "SELECT " +
            "ur.rowid, " +
            DEVICE_COLUMNS +
        "FROM " +
            "udger_deviceclass_regex ur " +
        "JOIN " +
            "udger_deviceclass_list ON udger_deviceclass_list.id = ur.deviceclass_id " +
        "WHERE " +
            "ur.rowid={0}"
        ;

    public static readonly String SQL_CLIENT_CLASS =
        "SELECT " +
            DEVICE_COLUMNS +
        "FROM " +
            "udger_deviceclass_list " +
        "JOIN " +
            "udger_client_class ON udger_client_class.deviceclass_id = udger_deviceclass_list.id " +
        "WHERE " +
            "udger_client_class.id = {0}";

    private static readonly String IP_COLUMNS =
            "ip_classification AS ip_classification, " +
            "ip_classification_code AS ip_classification_code, " +
            "ip_last_seen AS ip_last_seen, " +
            "ip_hostname AS ip_hostname, " +
            "ip_country AS ip_country, " +
            "ip_country_code AS ip_country_code, " +
            "ip_city AS ip_city, " +
            "name AS crawler_name, " +
            "ver AS crawler_ver, " +
            "ver_major AS crawler_ver_major, " +
            "family AS crawler_family, " +
            "family_code AS crawler_family_code, " +
            "family_homepage AS crawler_family_homepage, " +
            "vendor AS crawler_family_vendor, " +
            "vendor_code AS crawler_family_vendor_code, " +
            "vendor_homepage AS crawler_family_vendor_homepage, " +
            "family_icon AS crawler_family_icon, " +
            "'https://udger.com/resources/ua-list/bot-detail?bot=' || REPLACE(family, ' ', '%20') || '#id' || udger_crawler_list.id AS crawler_family_info_url, " +
            "last_seen AS crawler_last_seen, " +
            "crawler_classification AS crawler_category, " +
            "crawler_classification_code AS crawler_category_code, " +
            "respect_robotstxt AS crawler_respect_robotstxt ";

    public static readonly String SQL_IP =
        "SELECT " +
            IP_COLUMNS +
        "FROM " +
            "udger_ip_list " +
        "JOIN " +
            "udger_ip_class ON udger_ip_class.id=udger_ip_list.class_id " +
        "LEFT JOIN " +
            "udger_crawler_list ON udger_crawler_list.id=udger_ip_list.crawler_id " +
        "LEFT JOIN " +
            "udger_crawler_class ON udger_crawler_class.id=udger_crawler_list.class_id " +
        "WHERE " +
            "ip = {0} " +
        "ORDER BY " +
            "sequence";

    private static readonly String DATACENTER_COLUMNS =
        "name AS datacenter_name, " +
        "name_code AS datacenter_name_code, " +
        "homepage AS datacenter_homepage ";

    public static readonly String SQL_DATACENTER =
        "SELECT " +
            DATACENTER_COLUMNS +
        "FROM " +
            "udger_datacenter_range " +
        "JOIN " +
            "udger_datacenter_list ON udger_datacenter_range.datacenter_id = udger_datacenter_list.id " +
        "WHERE " +
            "iplong_from <= {0} AND iplong_to >= {1}";

    public static readonly String SQL_DATACENTER_RANGE6 =
        "SELECT " +
            DATACENTER_COLUMNS +
        "FROM " +
            "udger_datacenter_range6 " +
        "JOIN " +
            "udger_datacenter_list ON udger_datacenter_range6.datacenter_id=udger_datacenter_list.id " +
        "WHERE " +
            "iplong_from0 <= {0} AND iplong_to0 >= {1} AND " +
            "iplong_from1 <= {2} AND iplong_to1 >= {3} AND " +
            "iplong_from2 <= {4} AND iplong_to2 >= {5} AND " +
            "iplong_from3 <= {6} AND iplong_to3 >= {7} AND " +
            "iplong_from4 <= {8} AND iplong_to4 >= {9} AND " +
            "iplong_from5 <= {10} AND iplong_to5 >= {11} AND " +
            "iplong_from6 <= {12} AND iplong_to6 >= {13} AND " +
            "iplong_from7 <= {14} AND iplong_to7 >= {15}";

    public static readonly String SQL_DEVICE_REGEX =
        "SELECT " +
            "id," +
            "regstring " +
        "FROM " +
            "udger_devicename_regex " +
        "WHERE " +
            "os_family_code='{0}' AND (os_code='-all-' OR os_code='{1}') " +
        "ORDER BY sequence";

    public static readonly String SQL_DEVICE_NAME_LIST =
        "SELECT " +
            "marketname," +
            "brand_code," +
            "brand," +
            "brand_url," +
            "icon," +
            "icon_big " +
        "FROM " +
            "udger_devicename_list " +
        "JOIN " +
            "udger_devicename_brand ON udger_devicename_brand.id=udger_devicename_list.brand_id " +
        "WHERE " +
            "regex_id = '{0}' AND code = '{1}'";
    }
}
