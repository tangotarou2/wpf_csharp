using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace NUnitTestProject
{
    class JsonTest : TestBass
    {

        string googleSearchText = @"{
          'responseData': {
            'results': [
              {
                'GsearchResultClass': 'GwebSearch',
                'unescapedUrl': 'http://en.wikipedia.org/wiki/Paris_Hilton',
                'url': 'http://en.wikipedia.org/wiki/Paris_Hilton',
                'visibleUrl': 'en.wikipedia.org',
                'cacheUrl': 'http://www.google.com/search?q=cache:TwrPfhd22hYJ:en.wikipedia.org',
                'title': '<b>Paris Hilton</b> - Wikipedia, the free encyclopedia',
                'titleNoFormatting': 'Paris Hilton - Wikipedia, the free encyclopedia',
                'content': '[1] In 2006, she released her debut album...'
              },
              {
                'GsearchResultClass': 'GwebSearch',
                'unescapedUrl': 'http://www.imdb.com/name/nm0385296/',
                'url': 'http://www.imdb.com/name/nm0385296/',
                'visibleUrl': 'www.imdb.com',
                'cacheUrl': 'http://www.google.com/search?q=cache:1i34KkqnsooJ:www.imdb.com',
                'title': '<b>Paris Hilton</b>',
                'titleNoFormatting': 'Paris Hilton',
                'content': 'Self: Zoolander. Socialite <b>Paris Hilton</b>...'
              }
            ],
            'cursor': {
              'pages': [
                {
                  'start': '0',
                  'label': 1
                },
                {
                  'start': '4',
                  'label': 2
                },
                {
                  'start': '8',
                  'label': 3
                },
                {
                  'start': '12',
                  'label': 4
                }
              ],
              'estimatedResultCount': '59600000',
              'currentPageIndex': 0,
              'moreResultsUrl': 'http://www.google.com/search?oe=utf8&ie=utf8...'
            }
          },
          'responseDetails': null,
          'responseStatus': 200
        }";

        string m_jsondata = "";
        string m_tileset2 = "";

        [SetUp]
        public void Setup()
        {
            try {
                m_jsondata = System.IO.File.ReadAllText(@"../../../data/tileset.json");
                m_tileset2 = System.IO.File.ReadAllText(@"../../../data/tileset2.json");
            } catch (Exception e) {
                DebugLog(e.ToString());
            }
        }


        public class SearchResult
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Url { get; set; }
        }
        [Test]
        public void Test1()
        {
            //https://www.newtonsoft.com/json/help/html/SerializingJSONFragments.htm
            try {

                JObject googleSearch = JObject.Parse(googleSearchText);

                // get JSON result objects into a list
                IList<JToken> results = googleSearch["responseData"]["results"].Children().ToList();

                // serialize JSON results into .NET objects
                IList<SearchResult> searchResults = new List<SearchResult>();
                foreach (JToken result in results) {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    SearchResult searchResult = result.ToObject<SearchResult>();
                    searchResults.Add(searchResult);
                }


            } catch (Exception e) {
                DebugLog(e.ToString());
                Assert.That(false);
            }
            Assert.That(true);

            }

        public struct STest2 {
            public double minimum;
            public double maximum;
        }

        //https://mslgt.hatenablog.com/entry/2018/10/02/073652




        [Test]
        public void Test2()
        {
            try {
                JObject jobject = JObject.Parse(m_jsondata);

                // get JSON result objects into a list
                JToken result = jobject["properties"]["_zmax"];
                var  searchResult = result.ToObject<STest2>();
                //    searchResults.Add(searchResult);
                if(Approximately(searchResult.maximum, 215.03) ){
                    Assert.That(true);
                }


            } catch (Exception e) {
                DebugLog(e.ToString());
                Assert.That(false);
            }
        }

        [Test]
        public void Test3()
        {

            //https://sourcechord.hatenablog.com/entry/2015/06/11/233711
            try {
                
                JObject j_top = JObject.Parse(m_jsondata);
                //JToken result = j_top.SelectToken("root.children");
                var list_result = j_top.SelectTokens("root.children[0:]");

                foreach (var item in list_result) {
                    if (item.Type == JTokenType.Object) {

                        JObject job = (JObject)item;
                        var work = job.ToString();
                        DebugLog(work);

                        foreach (KeyValuePair<string ,JToken> keypair in job) {

                            JToken t_value = keypair.Value;
                            switch (keypair.Key) {
                                case "boundingVolume":
                                    break;
                                case "geometricError":
                                    break;
                                case "refine":
                                    break;
                                case "content":
                                    break;
                                case "children":
                                    DebugLog("------");
                                    break;
                                default:
                                    throw new Exception("default");
                                    break;
                                }


                            //switch (t_value.Type) 
                            //{
                            //    case JTokenType.Object:
                            //        DebugLog("------");
                            //        break;
                            //    case JTokenType.Array:
                            //        DebugLog("------");
                            //        break;
                            //    case JTokenType.Comment:
                            //        DebugLog("------");
                            //        break;
                            //    case JTokenType.Property: {
                            //            var prop = (JProperty)t_value;
                            //            DebugLog("------" + prop.Name);
                            //            break;
                            //        }
                            //    case JTokenType.String:
                            //        break;

                            //    default:
                            //        throw new Exception("default ");
                            //}
                            }
                        } else{ 
                        throw new Exception(@"JTokenType exception");
                    }
                }
            } catch (Exception e) {
                DebugLog(e.ToString());
                Assert.That(false);
            }
            Assert.That(true);

            }

        /*
                     'cursor': {
              'pages': [
                {
                  'start': '0',
                  'label': 1
                },
                {
                  'start': '4',
                  'label': 2
                },
                {
                  'start': '8',
                  'label': 3
                },
                {
                  'start': '12',
                  'label': 4
                }
              ],
              'estimatedResultCount': '59600000',
              'currentPageIndex': 0,
              'moreResultsUrl': 'http://www.google.com/search?oe=utf8&ie=utf8...'
            }
         */
        [Test]
        public void Test4()
        {
            /*
             JProperty : Value.Typeを使った分類
             */
            try {
                JObject j_top = JObject.Parse(googleSearchText);
                JToken result_token = j_top.SelectToken("responseData.cursor");

                foreach (JToken token in result_token) {
                    if (token.Type == JTokenType.Property) {
                        JProperty result_prop = token as JProperty;

                        Debug_Write(string.Format("{0}  :", result_prop.Name));
                        {
                            JToken Value = result_prop.Value;
                            switch (Value.Type) {
                                case JTokenType.Array:
                                    JArray list_ja = (JArray)Value;
                                    foreach ( var ja in list_ja){
                                        DebugLog(string.Format("{0}", ja.ToString()));
                                    }
                                    break;
                                case JTokenType.Integer:

                                   // var jal = (JValue)Value; 

                                    int m = Int32.Parse(Value.ToString());
                                    DebugLog(string.Format("{0}", m));
                                    Debug.Assert(m == 59600000 || m == 0);
                                    break;
                                case JTokenType.String:
                                    string sz = Value.ToString();
                                    DebugLog(string.Format("{0}", sz));

                                    break;
                                case JTokenType.Constructor:
                                case JTokenType.Property:
                                    break;
                                default:
                                    throw new Exception(" user exp");
                                }
                            }
                    } else{
                        DebugLog(string.Format("{0}", token.Type.ToString()));
                    }
                }
            } catch (Exception e) {
                DebugLog(e.ToString());
                Assert.That(false);
            }
            Assert.That(true);

            }
        /*
         JToken 共通の親 (継承元) 

         JObject オブジェクト (例: { "firstname" : "Subaru", "surname" : "Kokubun" }) は JObject、
         JArray : 配列 (例 : [ { "surname" : "Kokubun" }, { "surname" : "Matsuzaki" }, ... ] ) 、
         
         JValue : 文字列や数値などのプリミティブは JValue、
         JProperty :  keypair 
         */

        [Test]
        public void Test5()
        {
            try {
                JObject j_top = JObject.Parse(m_tileset2);
                JToken result_token = j_top.SelectToken("root.children");

                foreach (JToken token in result_token) {
                    DebugLog(string.Format("{0}", token.Type.ToString()));
                    if (token.Type != JTokenType.Object) {
                        DebugLog(string.Format("{0}", token.ToString()));

                    } else {

                        var t_jo = (JObject)token;
                        foreach (KeyValuePair<string, JToken> keypair in t_jo) {

                            var key = keypair.Key;
                            if (key == "boundingVolume") {
                                DebugLog(string.Format("{0}", keypair.Value.ToString()));
                            } else if (key == "geometricError") {
                                DebugLog(string.Format("{0}", keypair.Value.ToString()));

                            } else if (key == "refine") {
                                DebugLog(string.Format("{0}", keypair.Value.ToString()));

                            } else if (key == "content") {
                                DebugLog(string.Format("{0}", keypair.Value.ToString()));
                            } else if (key == "children") {
                                var work = keypair.Value.ToString();
                                DebugLog(string.Format("{0}", work));
                                if (keypair.Value.Type == JTokenType.Array) {
                                    var ja = keypair.Value as JArray;
                                    var t_list = ja.ToList<JToken>();
                                    foreach (var t in t_list) {
                                        string t_work = t.ToString();
                                        DebugLog(string.Format("{0}", t_work));
                                    }

                                } else {
                                    throw new Exception(" user exp");
                                }
                            }
                        }
                    }// else
                    }
            } catch (Exception e) {
                DebugLog(e.ToString());
                Assert.That(false);
            }
        }


        /*
{
"boundingVolume" : {
"region" : [ 2.4394637165321855, 0.6222458435725269, 2.439516766014341, 0.6222953837169973, 35.99695899989456, 88.21930257696658 ]
},
"refine" : "ADD",
"content" : {
"boundingVolume" : {
"region" : [ 2.4394637165321855, 0.6222458435725269, 2.439516766014341, 0.6222953837169973, 35.99695899989456, 88.21930257696658 ]
},

},
*/

        //キャストのための演算子としてimplicitとexplicitという変換演算子があります。




        //https://sourcechord.hatenablog.com/entry/2015/06/11/233711
        [Test]
        public async Task Test999()
        {
            Action action = () => { };
            await Task.Run(action);

            Assert.Pass();
        }

    }
}

