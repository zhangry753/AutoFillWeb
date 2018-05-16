using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Html = HtmlAgilityPack;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FillWebsite {
    public partial class Form1 : Form {
        private Excel.Application excelApp = new Excel.Application();
        private Excel.Workbook wbSave;
        private Excel.Workbook wbRead;
        private Dictionary<string, int> siteMap = new Dictionary<string, int>() {
            {"全部站点",0},{"美国",1},{"加拿大",2},{"英国",3},{"德国",4},
            {"法国",5},{"日本",6},{"西班牙",7},{"意大利",8}
        };
        private bool isStop = true;
            
        public Form1() {
            InitializeComponent();
            siteText.SelectedIndex = 0;
        }

        private void selectPathBtn_Click(object sender, EventArgs e) {
            string path = string.Empty;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择excel文件";
            fileDialog.Filter = "excel文件(*.xls,*.xlsx)|*.xls;*.xlsx";
            if (fileDialog.ShowDialog() == DialogResult.OK) {
                pathText.Text = fileDialog.FileName;
            }
        }
        private void selectSavePathBtn_Click(object sender, EventArgs e) {
            string path = string.Empty;
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "请选择结果保存位置";
            fileDialog.Filter = "excel文件(*.xlsx)|*.xlsx";
            if (fileDialog.ShowDialog() == DialogResult.OK) {
                savePathText.Text = fileDialog.FileName;
            }
        }
        private void howToGetCookieBtn_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("howToGetCookie.docx");
        }
        private void excelModelBtn_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("model.xlsx");
        }

        private void doBtn1_Click(object sender, EventArgs e) {
            string cookie = cookieText.Text;
            var path = pathText.Text;
            var savePath = savePathText.Text;
            if (!isStop) {
                MessageBox.Show("请不要同时运行两个任务");
                return;
            }
            if (cookie == ""){
                MessageBox.Show("请填写cookie");
                return;
            }
            if (path == "") {
                MessageBox.Show("请选择excel路径");
                return;
            }
            if (!File.Exists(path)) {
                MessageBox.Show("excel文件不存在");
                return;
            }
            if (!path.EndsWith("xlsx") && !path.EndsWith("xls")) {
                MessageBox.Show("所选文件不是excel文件(xls或xlsx)");
                return;
            }
            if (savePath == "") {
                MessageBox.Show("请选择结果保存路径");
                return;
            }
            if (File.Exists(savePath)) {
                var dialogResult = MessageBox.Show("结果保存文件已存在，是否覆盖？", "", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                    try {
                        File.Delete(savePath);
                    } catch (Exception) {
                        MessageBox.Show("结果保存文件覆盖失败，已被其他程序占用。");
                        return;
                    }
                else
                    return;
            }
            if (pageText.Text == "")
                pageText.Text = "0";
            var initPage = 0;
            if(!int.TryParse(pageText.Text,out initPage)){
                MessageBox.Show("页数只能填写数字。");
                return;
            }
            initPage = initPage < 0 ? 0 : initPage;
            //从cookie解析xsrf-token
            var xsrfStartIndex = cookie.IndexOf("XSRF-TOKEN=") + "XSRF-TOKEN=".Length;
            if (xsrfStartIndex >= cookie.Length) {
                MessageBox.Show("cookie错误，cookie应包含XSRF-TOKEN");
                return;
            }
            var xsrfEndIndex = cookie.IndexOf(";", xsrfStartIndex);
            var xsrfToken = cookie.Substring(xsrfStartIndex, xsrfEndIndex - xsrfStartIndex + 1);
            //更改状态，开始填写
            this.processLabel1.Text = "初始化中";
            this.doBtn1.Enabled = false;
            this.selectPathBtn.Enabled = false;
            this.selectSavePathBtn.Enabled = false;
            this.stopBtn1.Enabled = true;
            this.isStop = false;
            Task task = new Task(() => fillWebsite(path, savePath, cookie, xsrfToken, initPage));
            task.Start();
        }
        private void stopBtn1_Click(object sender, EventArgs e) {
            stopBtn1.Enabled = false;
            processLabel1.Text = "停止中";
            this.isStop = true;
        }


        private void doBtn2_Click(object sender, EventArgs e) {
            string cookie = cookieText.Text;
            var savePath = savePathText.Text;
            var asin = asinText.Text;
            var site = siteText.Text;
            if (!isStop) {
                MessageBox.Show("请不要同时运行两个任务");
                return;
            }
            if (cookie == "") {
                MessageBox.Show("请填写cookie");
                return;
            }
            if (savePath == "") {
                MessageBox.Show("请选择结果保存路径");
                return;
            }
            if (File.Exists(savePath)) {
                var dialogResult = MessageBox.Show("结果保存文件已存在，是否覆盖？", "", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                    try {
                        File.Delete(savePath);
                    } catch (Exception) {
                        MessageBox.Show("结果保存文件覆盖失败，已被其他程序占用。");
                        return;
                    } else
                    return;
            }
            if (pageText.Text == "")
                pageText.Text = "0";
            var initPage = 0;
            if (!int.TryParse(pageText.Text, out initPage)) {
                MessageBox.Show("页数只能填写数字。");
                return;
            }
            initPage = initPage < 0 ? 0 : initPage;
            if (asin == "") {
                MessageBox.Show("请填写ASIN");
                return;
            }
            //开始获取订单号
            this.processLabel2.Text = "初始化中";
            this.doBtn2.Enabled = false;
            this.selectSavePathBtn.Enabled = false;
            this.stopBtn2.Enabled = true;
            this.isStop = false;
            Task task = new Task(() => getAllOrderId(savePath, cookie, asin, site, initPage));
            task.Start();

        }
        private void stopBtn2_Click(object sender, EventArgs e) {
            stopBtn2.Enabled = false;
            processLabel2.Text = "停止中";
            this.isStop = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if(!isStop || processLabel1.Text=="停止中" || processLabel2.Text == "停止中") {
                DialogResult result = MessageBox.Show("请等待任务完成，或点击停止结束后，再关闭页面\n\n"
                    +"强行终止将无法保存订单号，但已填写的评价仍生效。是否强行终止？","是否退出",
                    MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel) {
                    e.Cancel = true;
                    return;
                }
            }
            excelApp.Quit();
            System.GC.GetGeneration(excelApp);

        }


#region utils
        /// <summary>
        /// 填写网页表单(程序核心代码)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="cookie"></param>
        /// <param name="xsrfToken"></param>
        /// <param name="initPage">从第几页开始往前填，0表示从末尾页</param>
        private void fillWebsite (string path, string savePath, string cookie, string xsrfToken, int initPage) {
            //结果保存excel
            wbSave = excelApp.Workbooks.Add();
            var wsSave = (Excel.Worksheet)wbSave.Worksheets[1];
            wsSave.Cells[1, 1] = "订单号";
            wsSave.Cells[1, 2] = "asin";
            wsSave.Cells[1, 3] = "国家";
            wsSave.Cells[1, 4] = "评价标题";
            wsSave.Cells[1, 5] = "评价内容";
            wsSave.Cells[1, 6] = "备注(错误信息)";
            //读取excel
            wbRead = excelApp.Workbooks.Open(path);
            var wsRead = (Excel.Worksheet)wbRead.Worksheets[1];
            int curRow = 2; //去除表头，从第二行开始读取
            int curPage = 0;
            try {
                var rowCount = wsRead.UsedRange.Rows.Count;
                //循环行
                string lastAsin = "";
                string lastSite = "";
                Stack<string> idStack = new Stack<string>();
                Stack<string> orderNoStack = new Stack<string>();
                string csrfToken = "";
                for (int saveRowIndex = 2; curRow <= rowCount; curRow++, saveRowIndex++) {
                    if (isStop) {
                        MessageBox.Show("停止填写。\n"
                                    + "当前excel第" + curRow + "行。\n"
                                    + "当前订单第" + curPage + "页。");
                        this.Invoke(new Action(() => processLabel1.Text = "进度：" + (curRow - 1) + "/" + rowCount));
                        return;
                    }
                    if (wsRead.Cells[curRow, 1].Value2 != null) { //按第一列是否有内容判断空行
                        string asin = wsRead.Cells[curRow, 1].Value2.ToString();
                        string site = wsRead.Cells[curRow, 2].Value2.ToString();
                        string title = wsRead.Cells[curRow, 3].Value2.ToString();
                        string content = wsRead.Cells[curRow, 4].Value2.ToString();
                        wsSave.Cells[saveRowIndex, 2] = asin;
                        wsSave.Cells[saveRowIndex, 3] = site;
                        wsSave.Cells[saveRowIndex, 4] = title;
                        wsSave.Cells[saveRowIndex, 5] = content;
                        if (asin.Trim() == "") {
                            wsSave.Cells[saveRowIndex, 6] = "asin不可为空。";
                            wsSave.Cells[saveRowIndex, 1].Interior.Color = Color.Red;
                            continue;
                        }
                        if (!siteMap.Keys.Contains(site)) {
                            wsSave.Cells[saveRowIndex, 6] = "未找到“" + site + "”国家选项。";
                            wsSave.Cells[saveRowIndex, 1].Interior.Color = Color.Red;
                            continue;
                        }
                        if (asin != lastAsin || site != lastSite) { //如果为新的商品
                            if (idStack.Count > 0 || curPage > 1) { //网页上还有未评价的订单
                                //wsSave.Cells[saveRowIndex, 6] = "页面上还有未评价的订单。订单第" + curPage + "页。";
                                //wsSave.Cells[saveRowIndex, 1].Interior.Color = Color.Red;
                            }
                            lastAsin = asin;
                            lastSite = site;
                            idStack.Clear();
                            orderNoStack.Clear();
                            //获取总页数
                            var pageCount = 2;
                            var htmlDoc = getProductHtmlByPage(asin, siteMap[site], cookie);
                            var pageLiSet = htmlDoc.DocumentNode.SelectNodes("//ul[@class='pagination']/li");
                            if (pageLiSet != null) { //只有一页时没有翻页按钮
                                pageCount = int.Parse(pageLiSet[pageLiSet.Count - 2].InnerText) + 1;
                            }
                            if (initPage > pageCount || initPage <= 0)
                                curPage = pageCount;
                            else
                                curPage = initPage + 1;
                        }
                        while (idStack.Count <= 0) { //请求下一页商品
                            if (curPage <= 1) {
                                wsSave.Cells[saveRowIndex, 6] = "找不到订单。";
                                wsSave.Cells[saveRowIndex, 1].Interior.Color = Color.Red;
                                break;
                            }
                            var htmlDoc = getProductHtmlByPage(asin, siteMap[site], cookie, --curPage);
                            //获取产品id，从button的方法中提取，initForm('formValidate',*******)
                            var productTrSet = htmlDoc.DocumentNode.SelectNodes("//tbody/tr");
                            foreach (var productTr in productTrSet) {
                                var productTdSet = productTr.SelectNodes("./td");
                                if (productTdSet.Count > 4) {
                                    var orderNo = productTdSet[3].InnerText.Trim(); //第4列为订单号
                                    if (orderNo != "") {
                                        var button = productTr.SelectSingleNode(".//i-button");
                                        var clickMethod = button.GetAttributeValue("@click", "");
                                        if (clickMethod.StartsWith("initForm")) {
                                            if (button.InnerText == "爱心捐赠感言") { //判断是否已填写过评价
                                                idStack.Push(clickMethod.Substring("initForm('formValidate',".Length, 7));
                                                orderNoStack.Push(orderNo);
                                            }
                                        }
                                    }
                                }
                            }
                            //获取csrf-token
                            var csrfMeta = htmlDoc.DocumentNode.SelectSingleNode("//meta[@name='csrf-token']");
                            if (csrfMeta == null) {
                                MessageBox.Show("获取网页权限失败(CSRF-Token)");
                                return;
                            }
                            csrfToken = csrfMeta.GetAttributeValue("content", "");
                        }
                        if (idStack.Count <= 0)
                            continue;
                        wsSave.Cells[saveRowIndex, 1] = orderNoStack.Pop();
                        //填写评价
                        string url = "http://www.dagobuy.com/evaluate";
                        var utf8 = Encoding.UTF8;
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        request.Method = "post";
                        request.Headers.Add("Cookie", cookie);
                        request.Headers.Add("X-CSRF-TOKEN", csrfToken);
                        request.Headers.Add("X-XSRF-TOKEN", xsrfToken);
                        request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                        request.ContentType = "application/json;charset=UTF-8";
                        request.Accept = "application/json, text/plain, */*";
                        var id = idStack.Pop();
                        var titleNoTrans = title.Replace("\\", "\\\\").Replace("\t", "\\t").Replace("\v", "\\v")
                            .Replace("\n", "\\n").Replace("\"", "\\\"").Replace("\0", "\\0")
                            .Replace("\a", "\\a").Replace("\b", "\\b").Replace("\r", "\\r").Replace("\f", "\\f");
                        var contentNoTrans = content.Replace("\\", "\\\\").Replace("\t", "\\t").Replace("\v", "\\v")
                            .Replace("\n", "\\n").Replace("\"", "\\\"").Replace("\0", "\\0")
                            .Replace("\a", "\\a").Replace("\b", "\\b").Replace("\r", "\\r").Replace("\f", "\\f");
                        string requestStr = "{\"id\":" + id + ",\"star\":5,"
                            + "\"title\":\"" + titleNoTrans + "\","
                            + "\"content\":\"" + contentNoTrans + "\","
                            + "\"epic\":[],\"evideo\":[]}";
                        byte[] buffer = utf8.GetBytes(requestStr.ToString());
                        request.ContentLength = buffer.Length;
                        request.GetRequestStream().Write(buffer, 0, buffer.Length);
                        try {
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            string result = "";
                            using (StreamReader reader = new StreamReader(response.GetResponseStream(), utf8)) {
                                result = reader.ReadToEnd();
                            }
                            response.Close();
                            var json = (JObject)JsonConvert.DeserializeObject(result);
                            var resultMsg = json.GetValue("msg").ToString();
                            if (resultMsg != "ok") {
                                wsSave.Cells[saveRowIndex, 6] = "订单评价不成功。" + Uri.UnescapeDataString(resultMsg) + "。订单第" + curPage + "页。";
                                wsSave.Cells[saveRowIndex, 1].Interior.Color = Color.Red;
                            }
                        } catch (WebException e) {
                            if (e.Message.Contains("500")) { //request格式有误，一般是评价字符串处理出错
                                wsSave.Cells[saveRowIndex, 6] = "评价内容无法处理。订单第" + curPage + "页。";
                                wsSave.Cells[saveRowIndex, 1].Interior.Color = Color.Red;
                            } else {
                                MessageBox.Show("cookie已失效或网站服务器拒绝访问，请重新输入cookie。\n"
                                    + "当前excel第" + curRow + "行。\n"
                                    + "当前订单第" + curPage + "页。\n\n"
                                    + "重新运行前请删除excel中做完的填写！！");
                                return;
                            }
                        } finally {
                            request.Abort();
                        }
                    }
                    this.Invoke(new Action(() => processLabel1.Text = "进度：" + curRow + "/" + rowCount));
                }
                //if (idStack.Count > 0 || curPage > 1) { //网页上还有未评价的订单
                //    wsSave.Cells[saveRowIndex, 6] = "页面上还有未评价的订单。订单第" + curPage + "页。";
                //    wsSave.Cells[saveRowIndex, 1].Interior.Color = Color.Red;
                //}
                MessageBox.Show("填写完毕！\n结果保存在" + savePath);
            } catch (WebException ex) {
                MessageBox.Show("cookie已失效或网站服务器拒绝访问，请重新输入cookie。\n"
                    + "当前excel第" + curRow + "行。\n"
                    + "当前订单第" + curPage + "页。\n\n"
                    + "重新运行前请删除excel中做完的填写！！");
            } catch (NullReferenceException e) {
                MessageBox.Show("空指针错误，一般是因为网站样式改变了，本软件已失效。", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                isStop = true;
                this.Invoke(new Action(() => {
                    this.doBtn1.Enabled = true;
                    this.selectPathBtn.Enabled = true;
                    this.selectSavePathBtn.Enabled = true;
                    this.stopBtn1.Enabled = false;
                }));
                if (wbSave != null) {
                    wbSave.Close(true, savePath);
                }
                if (wbRead != null)
                    wbRead.Close(false);
                excelApp.Quit();
                System.GC.GetGeneration(excelApp);
            }
        }

        /// <summary>
        /// 获取订单号，倒序
        /// </summary>
        /// <param name="savePath">订单号存储位置，excel</param>
        /// <param name="cookie"></param>
        /// <param name="asin"></param>
        /// <param name="site">国家</param>
        private void getAllOrderId (string savePath, string cookie, string asin, string site, int initPage) {
            //结果保存excel
            wbSave = excelApp.Workbooks.Add();
            var wsSave = (Excel.Worksheet)wbSave.Worksheets[1];
            int saveRowIndex = 1;
            wsSave.Cells[saveRowIndex, 1] = "订单号";
            saveRowIndex++;
            int curPage = 0;
            try {
                //获取总页数
                var pageCount = 1;
                var htmlDoc = getProductHtmlByPage(asin, siteMap[site], cookie);
                var pageLiSet = htmlDoc.DocumentNode.SelectNodes("//ul[@class='pagination']/li");
                if (pageLiSet != null) { //只有一页时没有翻页按钮
                    pageCount = int.Parse(pageLiSet[pageLiSet.Count - 2].InnerText) + 1;
                }
                if (initPage > pageCount || initPage <= 0)
                    curPage = pageCount;
                else
                    curPage = initPage;
                //倒序获取订单号
                for (; curPage >= 1; curPage--) {
                    if (isStop) {
                        MessageBox.Show("停止获取。\n"
                                    + "当前订单第" + curPage + "页。");
                        this.Invoke(new Action(() => processLabel2.Text = "进度：" + curPage + "/" + pageCount + "页"));
                        return;
                    }
                    this.Invoke(new Action(() => this.processLabel2.Text = "进度：" + curPage + "/" + pageCount + "页"));
                    htmlDoc = getProductHtmlByPage(asin, siteMap[site], cookie, curPage);
                    var productTrSet = htmlDoc.DocumentNode.SelectNodes("//tbody/tr");
                    for (int i = productTrSet.Count - 1; i >= 0; i--) {
                        var productTr = productTrSet[i];
                        var productTdSet = productTr.SelectNodes("./td");
                        if (productTdSet.Count > 4) {
                            var orderNo = productTdSet[3].InnerText.Trim();
                            if (orderNo != "") {
                                wsSave.Cells[saveRowIndex, 1] = orderNo;
                                saveRowIndex++;
                            }
                        }
                    }
                }
                MessageBox.Show("订单号获取完毕！\n结果保存在" + savePath);
            } catch (WebException) {
                MessageBox.Show("cookie已失效或网站服务器拒绝访问，请重新输入cookie。");
            } catch (NullReferenceException e) {
                MessageBox.Show("空指针错误，一般是因为网站样式改变了，本软件已失效。", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                isStop = true;
                this.Invoke(new Action(() => {
                    this.doBtn2.Enabled = true;
                    this.selectSavePathBtn.Enabled = true;
                    this.stopBtn2.Enabled = false;
                }));
                if (wbSave != null) {
                    wbSave.Close(true, savePath);
                }
                excelApp.Quit();
                System.GC.GetGeneration(excelApp);
            }
        }

        /// <summary>
        /// 请求网页并获取html文件
        /// </summary>
        /// <param name="asin"></param>
        /// <param name="site">国家</param>
        /// <param name="cookie"></param>
        /// <param name="page">第几页</param>
        /// <returns></returns>
        private Html.HtmlDocument getProductHtmlByPage(string asin, int site, string cookie, int page=1) {
            //获取产品页面
            string url = "http://www.dagobuy.com/mycfrlist?asin="+ asin 
                + "&amazon_orderid=&site="+ site 
                + "&type=1&page=" + page;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "get";
            request.Headers.Add("Cookie", cookie);
            request.Accept = "text/html, application/xhtml+xml, */*";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string html = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
                html = reader.ReadToEnd();
            }
            response.Close();
            request.Abort();
            //解析html
            var htmlDoc = new Html.HtmlDocument();
            htmlDoc.LoadHtml(html);
            return htmlDoc;
        }

        #endregion

    }
}
