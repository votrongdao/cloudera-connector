//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mojohive {
    
    
    #region Component Designer generated code 
    [global::net.sf.jni4net.attributes.JavaClassAttribute()]
    public partial class QlikViewMain : global::java.lang.Object {
        
        internal new static global::java.lang.Class staticClass;
        
        internal static global::net.sf.jni4net.jni.MethodId j4n_main0;
        
        internal static global::net.sf.jni4net.jni.MethodId j4n__ctorQlikViewMain1;
        
        [global::net.sf.jni4net.attributes.JavaMethodAttribute("()V")]
        public QlikViewMain() : 
                base(((global::net.sf.jni4net.jni.JNIEnv)(null))) {
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.ThreadEnv;
            using(new global::net.sf.jni4net.jni.LocalFrame(@__env, 10)){
            @__env.NewObject(global::mojohive.QlikViewMain.staticClass, global::mojohive.QlikViewMain.j4n__ctorQlikViewMain1, this);
            }
        }
        
        protected QlikViewMain(global::net.sf.jni4net.jni.JNIEnv @__env) : 
                base(@__env) {
        }
        
        public static global::java.lang.Class _class {
            get {
                return global::mojohive.QlikViewMain.staticClass;
            }
        }
        
        private static void InitJNI(global::net.sf.jni4net.jni.JNIEnv @__env, java.lang.Class @__class) {
            global::mojohive.QlikViewMain.staticClass = @__class;
            global::mojohive.QlikViewMain.j4n_main0 = @__env.GetStaticMethodID(global::mojohive.QlikViewMain.staticClass, "main", "([Ljava/lang/String;)V");
            global::mojohive.QlikViewMain.j4n__ctorQlikViewMain1 = @__env.GetMethodID(global::mojohive.QlikViewMain.staticClass, "<init>", "()V");
        }
        
        [global::net.sf.jni4net.attributes.JavaMethodAttribute("([Ljava/lang/String;)V")]
        public static void main(global::java.lang.String[] par0) {
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.ThreadEnv;
            using(new global::net.sf.jni4net.jni.LocalFrame(@__env, 12)){
            @__env.CallStaticVoidMethod(global::mojohive.QlikViewMain.staticClass, global::mojohive.QlikViewMain.j4n_main0, global::net.sf.jni4net.utils.Convertor.ParArrayStrongCp2J(@__env, par0));
            }
        }
        
        new internal sealed class ContructionHelper : global::net.sf.jni4net.utils.IConstructionHelper {
            
            public global::net.sf.jni4net.jni.IJvmProxy CreateProxy(global::net.sf.jni4net.jni.JNIEnv @__env) {
                return new global::mojohive.QlikViewMain(@__env);
            }
        }
    }
    #endregion
}