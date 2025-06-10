declare var math: math_main

declare module "math" {
    export = math;
}

interface math_main {
    eval: (XPathExpression: string) => number
}