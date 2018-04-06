echo "Binding stated"
 sharpie bind \
    -o Binding \
    -sdk iphoneos11.2 \
    -scope . \
        ./include/ZBarSDK/ZBarReaderViewController.h \
    -c \
        -Ibuild/Release-iphoneos/include -unified
