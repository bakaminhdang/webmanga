/*
    Copyright (c) 2019 Cristian José Jiménez Diazgranados

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
*/

/* Change page script */

/* Require jQuery */
/* Require "getters.js" */
/* Require "context.js" */
/* Require "evolution.js" */
/* Require "limits.js" */
/* Require "core.js" */

function forward() {
    changePage(getCurrentIndex() + 1);
}

function backward() {
    changePage(getCurrentIndex() - 1);
}

function firstPage() {
    changePage(0);
}

function lastPage() {
    changePage(core.n_ - 1);
}

function changePage(index) {
    if (index < core.n_) {
        loadImage(index);
        $("#page-selector > option[value='" + index + "']").prop(
            'selected',
            true
        );
    } else {
        deadEnd(core.exit_);
    }
    restartPosition();
}

function pageSelector() {
    loadImage(getCurrentIndex());
    restartPosition();
}

function loadImage(index) {
    $('#viewport').attr('src', core.pages_[index]);
    mutateNavbar(index, getWidth());
    pageCounter(index + 1);
}
