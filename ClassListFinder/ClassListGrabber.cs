using System.Collections.Generic;
using Newtonsoft.Json;
using PuppeteerSharp;
using System.Text;
using TextCopy;
using System;

namespace GetAnator {
    public static class ClassGrabber {
        public static async Task<string> GetList(string address, bool copy) {

            await new BrowserFetcher().DownloadAsync();

            using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            using var page = await browser.NewPageAsync();

            await page.GoToAsync(address);

            var result = await page.EvaluateExpressionAsync<string>(@"
                let titles = []
                let descriptions = []

                let a = document.querySelectorAll('#CourseList > div > div > div.col-sm-9 > div section .panel-course .panel')
                a.forEach(t => titles.push(t.querySelector('.panel-heading .panel-title a div span').textContent))
                a.forEach(d => descriptions.push(d.querySelector('.panel-collapse .panel-body').textContent
                    .replace(/\n+/g, '').replace(/\s+/g, ' ')
                    .replace(/Credits:\s*\d+(-\d+)?/, '')
                    .replace(/Prerequisites:.*/,'')
                    .trim()
                ))
                let result = [titles,descriptions]
                JSON.stringify(result)
            ");

            // Deserialize the result to a tuple
            var bruple = JsonConvert.DeserializeObject<List<List<string>>>(result);

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < bruple[0].Count; i++) {
                sb.Append($"{bruple[0][i]}\n{bruple[1][i]}\n\n");
            }

            return sb.ToString();
        }
    }
}