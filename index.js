"use strict";


function createIframes() {
    let mainIndex = 10; // Counter for the first number
    let index = 1; // Counter for the primary level

    const createIframe = () => {
        const url = `schoolAdminPages/${mainIndex}_${index}.html`;
        fetch(url, {method: 'HEAD'})
            .then(response => {
                if (response.ok) {
                    // Create iframe for the current file
                    const iframe = document.createElement('iframe');
                    iframe.id = `myFrame${mainIndex}_${index}`;
                    iframe.src = url;
                    iframe.width = "100%";
                    iframe.style.border = "none";
                    iframe.style.overflow = "hidden";

                    // On iframe load
                    iframe.onload = function () {
                        const iframeDocument = iframe.contentWindow.document;
                        const contentHeight = iframeDocument.body.scrollHeight;
                        iframe.style.height = contentHeight + 'px';
                        iframeDocument.body.style.overflow = 'hidden';

                        // Modify elements inside iframe
                        const elements = iframeDocument.querySelectorAll('.ring-tint');
                        elements.forEach(element => {
                            element.style.backgroundColor = "rgba(177,177,177,0.45)";
                            element.style.boxShadow = "2px 6px 8px rgba(0, 0, 0, 0.5)";
                            element.style.border = "1px solid #ffffff";
                        });
                    };

                    // Append to the body
                    document.body.appendChild(iframe);

                    // Check if this file is a nested page (ends with "_")
                    if (url.endsWith("_")) {
                        processNestedPages(index); // Handle nested files
                    }

                    // Continue to the next primary file
                    index++;
                    createIframe();
                } else {
                    // If no more primary files, increment main index and restart
                    mainIndex++;
                    index = 1;

                    // Stop mechanic: Terminate if mainIndex is not successful
                    if (mainIndex > 20) { // Assuming a limit for how far mainIndex should go
                        console.error('No more files found. Stopping script.');
                        return;
                    }
                    createIframe();
                }
            })
            .catch(() => console.error(`File ${url} does not exist`));
    };

    const processNestedPages = (parentIndex) => {
        let nestedIndex = 1;

        // Recursive function for nested pages
        const processNestedIframe = () => {
            const nestedUrl = `schoolAdminPages/${mainIndex}_${parentIndex}_${nestedIndex}.html`;
            fetch(nestedUrl, {method: 'HEAD'})
                .then(response => {
                    if (response.ok) {
                        // Create iframe for the nested file
                        const nestedIframe = document.createElement('iframe');
                        nestedIframe.id = `myFrame${mainIndex}_${parentIndex}_${nestedIndex}`;
                        nestedIframe.src = nestedUrl;
                        nestedIframe.width = "100%";
                        nestedIframe.style.border = "none";
                        nestedIframe.style.overflow = "hidden";

                        // On nested iframe load
                        nestedIframe.onload = function () {
                            const iframeDocument = nestedIframe.contentWindow.document;
                            const contentHeight = iframeDocument.body.scrollHeight;
                            nestedIframe.style.height = contentHeight + 'px';
                            iframeDocument.body.style.overflow = 'hidden';

                            // Modify elements inside nested iframe
                            const elements = iframeDocument.querySelectorAll('.ring-tint');
                            elements.forEach(element => {
                                element.style.backgroundColor = "rgba(177,177,177,0.45)";
                                element.style.boxShadow = "2px 6px 8px rgba(0, 0, 0, 0.5)";
                                element.style.border = "1px solid #ffffff";
                            });
                        };

                        // Append to the body, after parent iframe
                        document.body.appendChild(nestedIframe);

                        // Continue checking for more nested files
                        nestedIndex++;
                        processNestedIframe();
                    }
                })
                .catch(() => console.error(`Nested file ${nestedUrl} does not exist`));
        };

        processNestedIframe();
    };

    createIframe();
}

createIframes();