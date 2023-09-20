var simplemde;

function initializeMarkdownEditor() {
    console.log("initializeMarkdownEditor called")
    simplemde = new SimpleMDE();
}

function getMarkdownEditorValue() {
    if (simplemde == null) {
        console.log('simplemde null');
        initializeMarkdownEditor();
    }
    if (simplemde != null) {
        console.log('simpleMde.value', simplemde.value())
        return simplemde.value();
    }
    return '';
}
function setMarkdownEditorValue(value) {
    if (simplemde == null) {
        console.log('simplemde null');
        initializeMarkdownEditor();
    }
    if (simplemde != null) {
        console.log('simpleMde.value', value)
        simplemde.value(value);
    }
}
