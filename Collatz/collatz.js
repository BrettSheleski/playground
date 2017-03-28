/// <reference path="createjs-2015.11.26.min.js" />

Collatz = (function (createjs) {

    function Collatz(canvas, options) {
        var self = this;

        self.options = options || {};
        self.stage = new createjs.Stage(canvas);


        if (typeof self.options.width === 'undefined')
            self.options.width = this.defaultOptions.width;

        if (typeof self.options.length === 'undefined')
            self.options.length = this.defaultOptions.length;

        if (typeof self.options.angle === 'undefined')
            self.options.angle = this.defaultOptions.angle;
        
    }

    var p = Collatz.prototype;

    p.defaultOptions = {
        width: 10,
        length: 100,
        angle: 10,
    };

    function degreesToRadians(d) {
        return d / 180 * Math.PI;
    }
    
    function drawPoint(shape, p, i, n, c) {
        if (i <= n) {
            var angle = p.angle + c.options.angle;

            var nextPoint = {
                x: p.x + c.options.length * Math.cos(degreesToRadians(angle)),
                y: p.y + c.options.length * Math.sin(degreesToRadians(angle)),
                angle : angle
            }
            
            shape.graphics.lineTo(nextPoint.x, nextPoint.y);

            drawPoint(shape, nextPoint, i * 2, n, c);

            var x = (i - 1) / 3;

            if (x > 0 && x === Math.floor(x)) {
                angle = p.angle - c.options.angle;

                nextPoint = {
                    x: p.x + c.options.length * Math.cos(degreesToRadians(angle)),
                    y: p.y + c.options.length * Math.sin(degreesToRadians(angle)),
                    angle: angle
                }

                shape = c.createShape();
                shape.graphics.moveTo(p.x, p.y);

                shape.graphics.lineTo(nextPoint.x, nextPoint.y);

                drawPoint(shape, nextPoint, i * 2, n, c);
            }
        }
    }

    function randomColor() {
        return '#' + (Math.random() * 0xFFFFFF << 0).toString(16);
    }

    p.createShape = function () {
        var shape = new createjs.Shape();
        shape.graphics.setStrokeStyle(this.options.width, "round", "round");
        shape.graphics.beginStroke(randomColor());

        this.stage.addChild(shape);

        return shape;
    }

    p.draw = function (n) {

        var p = { x: 0, y: 100, angle: 0 };

        var shape = this.createShape();
        shape.graphics.moveTo(p.x, p.y);

        drawPoint(shape, p, 1, n, this);
        
        this.stage.addChild(shape);


        //shape = new createjs.Shape();
        //shape.graphics.beginFill("#ff0000").drawCircle(p.x, p.y, this.options.length);

        //this.stage.addChild(shape);

        this.stage.update();
    };

    


    return Collatz;
})(createjs)