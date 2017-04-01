/// <reference path="createjs-2015.11.26.min.js" />

Collatz = (function (createjs) {

    function Collatz(canvas, options) {
        var self = this;

        self.options = options || {};
        self.stage = new createjs.Stage(canvas);

        self.container = new createjs.Container();

        var p = null;

        self.container.on("mousedown", function(evt){
            p = {x : evt.stageX, y : evt.stageY};
        })

        self.container.on("pressmove", function(evt){
         
            self.container.x += (evt.stageX - p.x) / self.container.scaleX;
            self.container.y += (evt.stageY - p.y) / self.container.scaleY;

            self.stage.update();

            p = {x : evt.stageX, y : evt.stageY};
        });

        self.container.on("dblclick", function(evt){

            self.container.regX = evt.stageX / self.container.scaleX;
            self.container.regY = evt.stageY / self.container.scaleY;

            self.container.scaleX *= 1.1;
            self.container.scaleY *= 1.1;

            self.stage.update();
        })

        self.stage.addChild(self.container);


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
        shape.graphics.beginStroke("red");

        this.container.addChildAt(shape, 0);

        return shape;
    }

    p.draw = function (n) {


        this.container.removeAllChildren();

        var nodes = [];
        var allNodes = {};

        for(var i = 0 ; i < n; ++i){
            nodes[i] = new Node(i + 1);
            allNodes[(i + 1).toString()] = nodes[i];
        }

        for(var i = 0 ; i < n; ++i){
            nodes[i].calculate(nodes, allNodes);
        }

        var p = { x: 0, y: 100, angle: 0 };

        var shape = this.createShape();
        shape.graphics.moveTo(p.x, p.y);

        //drawPoint(shape, p, 1, n, this);

        nodes[0].draw(shape, p, this);
        
        this.container.addChild(shape);


        //shape = new createjs.Shape();
        //shape.graphics.beginFill("#ff0000").drawCircle(p.x, p.y, this.options.length);

        //this.stage.addChild(shape);

        this.stage.update();
    };


    function Node(val){
        var self = this;

        self.value = val;
        self.left = null;
        self.right = null;
        self.next = null;

        self.isCalculated = false;

    }

    Node.prototype.calculate = function(nodes, allNodes){
        if (!this.isCalculated){
                var nextValue = this.value % 2 == 0 ? this.value / 2 : (this.value * 3 + 1);
                var nextValueString = nextValue.toString();
                var nextNode;

                if (nextValueString in allNodes){
                    nextNode = allNodes[nextValueString];
                }
                else{
                    nextNode = new Node(nextValue);
                }
                this.next = nextNode;

                if (this.value % 2 == 0){
                    this.next.right = this;
                }
                else{
                    this.next.left = this;
                }
                
                this.isCalculated = true;

                nextNode.calculate(nodes, allNodes);
        }

        Node.prototype.draw = function(shape, p, c){
            if (!this.isDrawn){
                this.isDrawn = true;
                shape.graphics.lineTo(p.x, p.y);

                if (this.left != null){

                    var angle = p.angle - c.options.angle;

                    var leftPoint = {
                        x  : p.x + (c.options.length * Math.cos(degreesToRadians(angle))),
                        y  : p.y + (c.options.length * Math.sin(degreesToRadians(angle))),
                        angle : angle
                    };

                    var leftShape = c.createShape()
                    leftShape.graphics.moveTo(p.x, p.y);

                    this.left.draw(leftShape, leftPoint, c);
                }

                if (this.right != null){
                    var angle = p.angle + c.options.angle;

                    var rightPoint = {
                        x  : p.x + (c.options.length * Math.cos(degreesToRadians(angle))),
                        y  : p.y + (c.options.length * Math.sin(degreesToRadians(angle))),
                        angle : angle
                    };

                    this.right.draw(shape, rightPoint, c);
                }    
            }
        }
    };

    return Collatz;
})(createjs)