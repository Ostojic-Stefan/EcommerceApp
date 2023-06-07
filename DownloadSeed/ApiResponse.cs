using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DownloadSeed
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ActiveFilters
    {
        public List<object> facets { get; set; }
        public List<object> price { get; set; }
    }

    public class AggFull
    {
        public Meta meta { get; set; }
        public int doc_count { get; set; }
        //public Facets facets { get; set; }
    }

    public class AggFullFiltered
    {
        public Meta meta { get; set; }
        public int doc_count { get; set; }
        //public Facets facets { get; set; }
    }

    public class Aggregations
    {
        public AggFullFiltered agg_full_filtered { get; set; }
        public MaxPrice max_price { get; set; }
        public Brands brands { get; set; }
        public MinPrice min_price { get; set; }
        public List<object> asortiman { get; set; }
        public AggFull agg_full { get; set; }
    }

    public class Brands
    {
        public Meta meta { get; set; }
        public int doc_count { get; set; }
        public Names names { get; set; }
    }

    public class Bucket
    {
        public string key { get; set; }
        public int doc_count { get; set; }
        public SumTop sum_top { get; set; }
        public FacetValue facetValue { get; set; }
        public MaxPos max_pos { get; set; }
    }

    public class CustomerReviews
    {
        public int count { get; set; }
        public double value { get; set; }
    }

    public class EnergySticker
    {
        public object color { get; set; }
        public object img { get; set; }
        public object hover { get; set; }
        public object name { get; set; }
        public object label { get; set; }
    }

    public class Facet
    {
        public string facetvalue { get; set; }

        public int facetid { get; set; }

        public int facetnameposition { get; set; }

        public string facetname { get; set; }

        public int facetposition { get; set; }
        public int doc_count { get; set; }
        public FacetName facetName { get; set; }
    }

    public class FacetName
    {
        public int doc_count_error_upper_bound { get; set; }
        public int sum_other_doc_count { get; set; }
        public List<Bucket> buckets { get; set; }
    }

    public class FacetValue
    {
        public int doc_count_error_upper_bound { get; set; }
        public int sum_other_doc_count { get; set; }
        public List<Bucket> buckets { get; set; }
    }

    public class Hit
    {
        public string _index { get; set; }
        public string _type { get; set; }
        public string _id { get; set; }
        public double _score { get; set; }
        public Source _source { get; set; }
        public int total { get; set; }
        public double max_score { get; set; }
        public List<Hit> hits { get; set; }
    }

    public class Image
    {
        public string image { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Installment
    {
        public string label { get; set; }
        public double value { get; set; }
        public string formated { get; set; }
        public string @class { get; set; }
        public string monet { get; set; }
        public string helper { get; set; }
    }

    public class MaxPos
    {
        public int value { get; set; }
    }

    public class MaxPrice
    {
        public Meta meta { get; set; }
        public int doc_count { get; set; }
        public Price price { get; set; }
    }

    public class Meta
    {
    }

    public class MinPrice
    {
        public Meta meta { get; set; }
        public int doc_count { get; set; }
        public Price price { get; set; }
    }

    public class Names
    {
        public int doc_count_error_upper_bound { get; set; }
        public int sum_other_doc_count { get; set; }
        public List<Bucket> buckets { get; set; }
    }

    public class NumberSort
    {
        public int final_gross_price { get; set; }
    }

    public class Old
    {
        public string label { get; set; }
        public int value { get; set; }
        public string formated { get; set; }
        public string @class { get; set; }
        public string monet { get; set; }
    }

    public class Price
    {
        public string label { get; set; }
        public int value { get; set; }
        public string formated { get; set; }
        public string @class { get; set; }
        public string monet { get; set; }
    }

    public class Prices
    {
        public Price price { get; set; }
        public Old old { get; set; }
        public Saving saving { get; set; }
        public Installment installment { get; set; }
    }

    public class Hits
    {
        public int? Total { get; set; }
        public double? MaxScore { get; set; }
        public List<Hit> hits { get; set; }
    }

    public class Root
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public Shards _shards { get; set; }
        public Hits hits { get; set; }
        public Aggregations aggregations { get; set; }
        public ActiveFilters active_filters { get; set; }
        public int totalPages { get; set; }
        public int currentPage { get; set; }
        public int limit { get; set; }
    }

    public class Saving
    {
        public string label { get; set; }
        public int value { get; set; }
        public string formated { get; set; }
        public string @class { get; set; }
        public string monet { get; set; }
    }

    public class SearchData
    {
        public string full_text { get; set; }
        public string full_text_latinized { get; set; }
        public string full_text_boosted { get; set; }
        public string full_text_specification { get; set; }
    }

    public class SearchResultData
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string ean { get; set; }
        public string master_id { get; set; }
        public object energy { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string brand { get; set; }
        public string brand_id { get; set; }
        public int gigadrive { get; set; }
        public int online_buy { get; set; }
        public int outlet { get; set; }
        public string brand_image { get; set; }
        public string price { get; set; }
        public string price_retail { get; set; }
        public string price_history { get; set; }
        public List<SpecificationSummary> specification_summary { get; set; }
        public string small_image { get; set; }
        public string image { get; set; }
        public string big_image { get; set; }
        public CustomerReviews customer_reviews { get; set; }
        public Prices prices { get; set; }
        public EnergySticker energy_sticker { get; set; }
        public object energy_file { get; set; }
        public Stickers stickers { get; set; }
        public string img { get; set; }
        public int statistic_visits { get; set; }
        public double statistic_rating { get; set; }
        public int statistic_votes { get; set; }
        public string gift_url { get; set; }
        public object gift_start_date { get; set; }
        public object gift_end_date { get; set; }
        public List<object> promocode_id { get; set; }
        public int daily_deal { get; set; }
        public int daily_promotion { get; set; }
        public int stock { get; set; }
        public int shock { get; set; }
        public int top { get; set; }
        public string category { get; set; }
        public int category_id { get; set; }
        public string category_slug { get; set; }
        public string subcategory { get; set; }
        public int subcategory_id { get; set; }
        public string subcategory_slug { get; set; }
        public int product_focus { get; set; }
        public int parent_id { get; set; }
        public string group_name { get; set; }
        public string group_slug { get; set; }
        public string match_slug { get; set; }
        public string url { get; set; }
    }

    public class Shards
    {
        public int total { get; set; }
        public int successful { get; set; }
        public int skipped { get; set; }
        public int failed { get; set; }
    }

    public class Source
    {
        public SearchResultData search_result_data { get; set; }
        public SearchData search_data { get; set; }
        public List<string> suggestion_terms { get; set; }
        public NumberSort number_sort { get; set; }
        public List<Facet> facets { get; set; }
    }

    public class SpecificationSummary
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Stickers
    {
        public List<object> top { get; set; }
        public List<object> bottom { get; set; }
        public Image image { get; set; }
    }

    public class SumTop
    {
        public int value { get; set; }
    }



}
