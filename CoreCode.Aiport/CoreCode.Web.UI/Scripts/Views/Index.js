function Index() {
    this.ctrlActions = new ControlActions();
    this.init = function() {
        var instance = this;
        instance.getFaqs();
    }
    this.getFaqs = function() {
        var instance = this;
        instance.ctrlActions.GetFromAPI("getFAQS", "", function(response) {
            if (response.Data) {
                var faqContainer = document.getElementById("faqAccordion");
                var template = document.querySelector(".faq-template");
                if (faqContainer) {
                    
                    for (var counter = 0; counter < response.Data.length; counter++) {
                        var clonedTemplate = template.cloneNode(true);
                        var templateTitle = clonedTemplate.querySelector(".template-button-title");
                        var templateBody = clonedTemplate.querySelector(".template-body");
                        var collapsableBody = clonedTemplate.querySelector(".template-collapsable");
                        templateTitle.innerText = response.Data[counter].Question;
                        templateTitle.dataset.target = "#faqCollapsable_" + counter;
                        templateTitle.setAttribute("aria-controls", "faqCollapsable_" + counter);
                        templateBody.innerText = response.Data[counter].Answer;
                        faqContainer.appendChild(clonedTemplate);
                        collapsableBody.setAttribute("id", "faqCollapsable_" + counter);
                        collapsableBody.dataset.parent = "#faqAccordion";
                        clonedTemplate.style.display = "block";
                        //Build HTML Row.
                        //Filter if the element
                        //Add FAQID to the Div
                        //Modify Title with Question
                        //Modify Content with Answer
                        //Append Row to the DOM
                        // 
                    }
                }
            }
        });
    }
}

$(document).ready(function() {
    var indexInstance = new Index();
    indexInstance.init();
});